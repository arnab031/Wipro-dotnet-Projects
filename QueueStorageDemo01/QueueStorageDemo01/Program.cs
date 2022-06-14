using System;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace QueueStorageDemo01
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string cs1 = "DefaultEndpointsProtocol=https;AccountName=arnabstorage31;AccountKey=ENZHQh+KL1CiBEByQVE28RtGCBpvsjCykZQJsR1JUP488OWsAmqD478femo7rGhaaixd+CY4Luuw+ASt7gkiMQ==;EndpointSuffix=core.windows.net";

            QueueClient queue = new QueueClient(cs1, "patients");
            string ch = "yes";
            string value;
            do
            {
                Console.Write("Enter patient name: ");
                string name = Console.ReadLine();
                value = String.Join(" ", name);
                // string value = name;
                await InsertMessageAsync(queue, value);
                Console.WriteLine($"Sent: {value}");

                Console.Write("Do you want to add a patient[yes/no]: ");
                ch = Console.ReadLine();
            } while (ch != "no");

            Console.WriteLine("list of patients...");
            //do
            //{
            //    value = await RetrieveNextMessageAsync(queue);
            //    Console.WriteLine($"Received: {value}");
            //} while (value != null);

        }
        //Enque: Add message in the queue
        static async Task InsertMessageAsync(Azure.Storage.Queues.QueueClient theQueue, string newMessage)
        {
            if (null != await theQueue.CreateIfNotExistsAsync())
            {
                Console.WriteLine("The queue was created.");
            }

            await theQueue.SendMessageAsync(newMessage);
        }
        //Deque: Remove message in the queue
        static async Task<string> RetrieveNextMessageAsync(Azure.Storage.Queues.QueueClient theQueue)
        {
            if (await theQueue.ExistsAsync())
            {
                QueueProperties properties = await theQueue.GetPropertiesAsync();

                if (properties.ApproximateMessagesCount > 0)
                {
                    QueueMessage[] retrievedMessage = await theQueue.ReceiveMessagesAsync(1);
                    string theMessage = retrievedMessage[0].Body.ToString();
                    await theQueue.DeleteMessageAsync(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
                    return theMessage;
                }

                return null;
            }

            return null;
        }
    }
}