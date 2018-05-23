using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using QRCoder;
using stellar_dotnetcore_sdk;
using stellar_dotnetcore_sdk.requests;
using stellar_dotnetcore_sdk.responses;
using stellar_dotnetcore_sdk.responses.operations;
using static QRCoder.PayloadGenerator;

namespace TestConsole
{
    public class Program
    {
        //For testing use the following account info, this only exists on test network and may be wiped at any time...
        //Public: GAZHWW2NBPDVJ6PEEOZ2X43QV5JUDYS3XN4OWOTBR6WUACTUML2CCJLI
        //Secret: SCD74D46TJYXOUXFC5YOA72UTPCCVHK2GRSLKSPRB66VK6UJHQX2Y3R3

        public static async Task Main(string[] args)
        {
            // GAZHWW2NBPDVJ6PEEOZ2X43QV5JUDYS3XN4OWOTBR6WUACTUML2CCJLI

            BitcoinAddress btcGen = new BitcoinAddress("175tWpb8K1S7NmH4Zx6rewF9WQrcZv245W", 1.5d);
            string payload = btcGen.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save("Test.png");


            //AsciiQRCode qrCodeAcsii = new AsciiQRCode(qrCodeData);

            //Console.WriteLine("");
            //Console.WriteLine(qrCodeAcsii.GetGraphic(1));

            //Network.UseTestNetwork();
            //var server = new Server("https://horizon-testnet.stellar.org");

            //await GetLedgerTransactions(server);
            //await ShowAccountTransactions(server);

            ////Streams are Maybe fixed? in this API until a resolution is found for the HttpClient issue
            //Console.WriteLine("-- Streaming All New Operations On The Network --");

            //server.Operations
            //    .Cursor("now")
            //    .Order(OrderDirection.ASC)
            //    .Stream((sender, response) => { ShowOperationResponse(response); })
            //    .Connect();

            Console.ReadLine();
        }


        private static async Task ShowAccountTransactions(Server server)
        {
            Console.WriteLine("-- Show Account Transactions (ForAccount) --");

            var transactions = await server.Transactions
                .ForAccount(KeyPair.FromAccountId("GAZHWW2NBPDVJ6PEEOZ2X43QV5JUDYS3XN4OWOTBR6WUACTUML2CCJLI"))
                .Execute();

            ShowTransactionRecords(transactions.Records);
            Console.WriteLine();
        }

        private static async Task GetLedgerTransactions(Server server)
        {
            Console.WriteLine("-- Show Ledger Transactions (ForLedger) --");
            // get a list of transactions that occurred in ledger 1400
            var transactions = await server.Transactions
                .ForLedger(2365)
                .Execute();

            ShowTransactionRecords(transactions.Records);
            Console.WriteLine();
        }

        private static void ShowTransactionRecords(List<TransactionResponse> transactions)
        {
            foreach (var tran in transactions)
                ShowTransactionRecord(tran);
        }

        private static void ShowTransactionRecord(TransactionResponse tran)
        {
            Console.WriteLine($"Ledger: {tran.Ledger}, Hash: {tran.Hash}, Fee Paid: {tran.FeePaid}");
        }

        private static void ShowOperationResponse(OperationResponse op)
        {
            Console.WriteLine($"Id: {op.Id}, Source: {op.SourceAccount.AccountId}, Type: {op.Type}");
        }
    }
}