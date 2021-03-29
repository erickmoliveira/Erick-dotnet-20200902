using FitnessFoods.Core.Entidades;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Core.Services
{

    public class ImportProductsService : IImportProductsService
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<CronImportations> _cronImportations;
        private string url = "https://challenges.coode.sh/food/data/json/";
        private string urlFiles = "https://challenges.coode.sh/food/data/json/index.txt";
        private List<string> listFileName;

     
        public ImportProductsService(IDbClient dbClient)
        {
            _products = dbClient.GetProductsColletion();
            _cronImportations = dbClient.GetCronColletion();
        }



        public void GetListFileNames()
        {
            listFileName = new List<string>();
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlFiles);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (result != "")
                    {
                        string[] words = result.Split('\n');

                        foreach (var item in words)
                        {
                            if(item!="")
                                listFileName.Add(item);
                        }
                        //resultado = result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (false)
            {
               // ImportProducts();
            }
           
        }


        public void ImportProducts()
        {
           
              

                if (listFileName == null)
                    GetListFileNames();

                int imports = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                foreach (var item in listFileName)
                {
                    var File = GetFileProduct(item);

                    if (File != "")
                    {

                    
                        using (WebClient client = new WebClient())
                        using (Stream stream = client.OpenRead(Environment.CurrentDirectory + "//" + item.Replace(".gz", "")))
                        using (StreamReader streamReader = new StreamReader(stream))
                        using (JsonTextReader reader = new JsonTextReader(streamReader))
                        {
                            reader.SupportMultipleContent = true;

                            var serializers = new JsonSerializer();
                            int limit = 0;
                            while (reader.Read() && limit < 100)
                            {
                                if (reader.TokenType == JsonToken.StartObject)
                                {
                                    Product product = serializers.Deserialize<Product>(reader);
                                    product.Code = product.Code.Replace(@"""", "");
                                    product.Imported_t = DateTime.Now;
                                    product.Status = StatusEnum.published;

                                    var _producDb = _products.Find(p => p.Code == product.Code).FirstOrDefault();

                                    if (_producDb != null)
                                    {
                                        _products.ReplaceOne(p => p.Code == product.Code, product);
                                        imports++;
                                    }
                                    else
                                    {
                                        _products.InsertOne(product);
                                        imports++;
                                    }
                                  
                                }
                                limit++;
                            }

                          
                        }
                    }
                }

                if (imports > 0)
                {
                    CronImportations cron = new CronImportations();
                    cron.ImportDateTime = DateTime.Now;
                    cron.NumberofObjects = imports;
                    watch.Stop();
                    cron.ImportTime = watch.ElapsedMilliseconds.ToString();

                    _cronImportations.InsertOne(cron);
                }
                else
                {
                    watch.Stop();
                }

               

            
            
           
        }
        public string GetFileProduct(string nameFile)
        {
            String resultado = "";
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(new Uri(url + nameFile), Environment.CurrentDirectory+"//"+nameFile);

                if (File.Exists(Environment.CurrentDirectory + "//" + nameFile))
                {
               

                    using (FileStream fInStream = new FileStream(Environment.CurrentDirectory + "//" + nameFile,
                    FileMode.Open, FileAccess.Read))
                    {
                        using (GZipStream zipStream = new GZipStream(fInStream, CompressionMode.Decompress))
                        {
                            using (FileStream fOutStream = new FileStream(Environment.CurrentDirectory + "//" + nameFile.Replace(".gz", ""),
                            FileMode.Create, FileAccess.Write))
                            {
                                byte[] tempBytes = new byte[4096];
                                int i;
                                while ((i = zipStream.Read(tempBytes, 0, tempBytes.Length)) != 0)
                                {
                                    fOutStream.Write(tempBytes, 0, i);
                                }
                            }
                        }
                        resultado = Environment.CurrentDirectory + "//" + nameFile.Replace(".gz", "");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resultado;
        }
    }
}
