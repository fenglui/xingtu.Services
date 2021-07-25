using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace xingtu.Services
{
    public class XingTuConfig
    {
        public string csrftoken { get; set; }

        public string Cookie { get; set; }
    }
    public static class ToutiaoTool
    {
        /// <summary>
        /// 星图请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="referer"></param>
        /// <returns></returns>
        public static String StarRequest(XingTuConfig cfg, string url, string referer = @"https://star.toutiao.com/ad/market", string serviceName = "", string serviceMethod = "", IWebProxy proxy = null)
        {
            HttpWebResponse response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Proxy = proxy;
                request.KeepAlive = true;
                if (String.IsNullOrEmpty(serviceName) == false)
                {
                    request.Headers.Add("x-star-service-name", serviceName);
                }
                request.Accept = "application/json, text/plain, */*";
                string csrftoken = cfg.csrftoken;
                request.Headers.Add("X-CSRFToken", csrftoken);
                request.Headers.Add("x-login-source", @"1");

                if (String.IsNullOrEmpty(serviceMethod) == false)
                {
                    request.Headers.Add("x-star-service-method", serviceMethod);
                }

                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.182 Safari/537.36 Edg/88.0.705.81";
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Sec-Fetch-Dest", @"empty");
                request.Referer = referer;
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                // TODO br 支持 
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en-US;q=0.8,en;q=0.7");

                request.Headers.Set(HttpRequestHeader.Cookie, cfg.Cookie);

                StreamReader responseReader = null;
                string responseData = String.Empty;
                Stream myStream = null;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    myStream = response.GetResponseStream();
                }
                catch
                {
                    Console.WriteLine("连接错误");
                    return null;
                }
                finally
                {
                    if (null != responseReader)
                    {
                        responseReader.Close();
                        responseReader = null;
                    }
                }

                try
                {
                    //如果包含GZIP,需要解压
                    if (!string.IsNullOrEmpty(response.ContentEncoding) && response.ContentEncoding.ToUpper().IndexOf("GZIP") > -1)
                    {
                        responseReader =
                        new StreamReader(new GZipStream(myStream, CompressionMode.Decompress), Encoding.Default);
                    }
                    else if (response.ContentEncoding.ToLower() == "br")
                    {
                        // TODO BrotliStream
                    }
                    else
                    {
                        responseReader = new StreamReader(myStream, Encoding.Default);
                    }
                    responseData = responseReader.ReadToEnd();
                    return responseData;
                }
                catch (Exception ex)
                {
                    return $"连接错误 { ex.Message }";
                }
                //catch
                //{
                //    return "连接错误";
                //}
                finally
                {
                    if (null != responseReader)
                    {
                        responseReader.Close();
                        responseReader = null;
                    }
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (response != null) response.Close();
                return null;
            }

            return null;
        }
    }
}
