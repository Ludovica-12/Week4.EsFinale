using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Week4.EsFinale.Client.Contract;

namespace Week4.EsFinale.Client
{
    internal class Menu
    {
        internal static void Start()
        {
            bool quit = false;
            char choice;
            do
            {
                Console.WriteLine("Seleziona un'opzione del menu" +
                "\n[ 1 ] - Crea un nuovo ordine" +
                "\n[ 2 ] - Elimina un ordine" +
                "\n[ 3 ] - Modifica dati di un ordine" +
                "\n[ 4 ] - Visualizza tutti gli ordini" +
                "\n[ q ] - ESCI");



                choice = Console.ReadKey().KeyChar;



                switch (choice)
                {
                    case '1':
                        AddOrdine();
                        break;
                    case '2':
                        DeleteOrdine();
                        break;
                    case '3':
                        UpdateOrdine();
                        break;
                    case '4':
                        FetchOrdine();
                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Scelta sconosciuta.");
                        break;
                }



            } while (!quit);
        }

        private static void FetchOrdine()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage fetchRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44371/api/order") 

            };

            HttpResponseMessage fetchResponse = client.SendAsync(fetchRequest).Result;

            if (fetchResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = fetchResponse.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<OrderContract>>(data); 

                foreach (var d in result)
                {
                    Console.WriteLine($"{d.DataOrdine} - {d.CodiceOrdine} - {d.CodiceProdotto} - {d.Importo}");
                }

            }
        }

        private static void UpdateOrdine()
        {
            
            int id = GetInt("Id");
            OrderContract order = GetById(id);
            if (order != null)
            {
                char choice;

                do
                {
                    Console.WriteLine("Vuoi modificare la data dell'ordine?");
                    choice = Char.ToLower(Console.ReadKey().KeyChar);
                } while (choice != 'y' && choice != 'n');

                if (choice == 'y')
                    //order.DataOrdine = DateTime.Parse(Console.ReadLine());
                    order.DataOrdine = InserciData();

                do
                {
                    Console.WriteLine("Vuoi modificare il CodiceOrdine?");
                    choice = Char.ToLower(Console.ReadKey().KeyChar);
                } while (choice != 'y' && choice != 'n');

                if (choice == 'y')
                    order.CodiceOrdine = SetString("codiceOrdine");

                do
                {
                    Console.WriteLine("Vuoi modificare il CodiceProdotto?");
                    choice = Char.ToLower(Console.ReadKey().KeyChar);
                } while (choice != 'y' && choice != 'n');

                if (choice == 'y')
                    order.CodiceProdotto = SetString("codiceProdotto");

                do
                {
                    Console.WriteLine("Vuoi modificare l'importo?");
                    choice = Char.ToLower(Console.ReadKey().KeyChar);
                } while (choice != 'y' && choice != 'n');

                if (choice == 'y')
                    //order.Importo = decimal.Parse(Console.ReadLine());
                    order.Importo = InserisciImporto();


                HttpClient client = new HttpClient();
                HttpRequestMessage req = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("https://localhost:44371/api/order" + id)
                };

                string orderJson = JsonConvert.SerializeObject(order);

                req.Content = new StringContent(
                    orderJson,
                    Encoding.UTF8,
                    "application/json"
                    );

                var res = client.SendAsync(req).Result;

                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Hai modificato l'ordine");
                }

        }

            else
                Console.WriteLine("Errore");
        }

        private static void DeleteOrdine()
        {
            int id = GetInt("Id");

            HttpClient client = new HttpClient();

            HttpRequestMessage req = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:44371/api/order" + id)
            };

            HttpResponseMessage res = client.SendAsync(req).Result;

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine("L'ordine è stato eliminato");
            }
            else
                Console.WriteLine("Errore");

        }

        private static void AddOrdine()
        {
            Console.Clear();
            Console.WriteLine("Nuovo Ordine");

            DateTime dataOrdine = InserciData();
            string codiceOrdine = SetString("codiceOrdine");
            string codiceProdotto = SetString("codiceProdotto");
            decimal importo = InserisciImporto();

            HttpClient client = new HttpClient();
            HttpRequestMessage req = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:44371/api/order")
            };

            OrderContract order = new OrderContract()
            {
                DataOrdine = dataOrdine,
                CodiceOrdine = codiceOrdine,
                CodiceProdotto = codiceProdotto,
                Importo = importo
            };

            string orderJson = JsonConvert.SerializeObject(order);

            req.Content = new StringContent(
                orderJson,
                Encoding.UTF8,
                "application/json"
                );

            var res = client.SendAsync(req).Result;

            if (res.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                var o = JsonConvert.DeserializeObject<OrderContract>(data);
                Console.WriteLine($"Hai aggiunto l'ordine {o.DataOrdine} - {o.CodiceOrdine} - {o.CodiceOrdine} - {o.Importo}");
            }
        }

        private static decimal InserisciImporto()
        {
            Console.WriteLine("inserisci il nuovo importo:");
            decimal importo = decimal.Parse(Console.ReadLine());
            return importo;
        }

        private static string SetString(string keyword, int l = 0)
        {
            string toReturn;
            if (l == 0)
            {
                do
                {
                    Console.WriteLine($"\nInserisci {keyword}:");
                    toReturn = Console.ReadLine();
                } while (toReturn.Trim().Length <= 0);
            }
            else
            {
                do
                {
                    Console.WriteLine($"\nInserisci {keyword}:");
                    toReturn = Console.ReadLine();
                } while (toReturn.Trim().Length < l && toReturn.Trim().Length > l);
            }
            return toReturn;
        }

        private static int GetInt(string v)
        {
            int toReturn;
            Console.WriteLine($"Inserisci {v}");

            while (!int.TryParse(Console.ReadLine(), out toReturn) || toReturn < 1)
            {
                Console.WriteLine("Inserisci un valore valido");
            }
            return toReturn;
        }

        private static OrderContract GetById(int id)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage fetchRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44371/api/order" + id)

            };

            HttpResponseMessage fetchResponse = client.SendAsync(fetchRequest).Result;

            if (fetchResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = fetchResponse.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<OrderContract>(data);

                return result;

            }

            else
                return null;
        }

        private static DateTime InserciData()
        {
            Console.WriteLine("inserisci la nuova data:");
            DateTime dataOrdine = DateTime.Parse(Console.ReadLine());
            return dataOrdine;
        }
    }
}