using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*----------------------------------------------------------------
    Copyright (C) 2017 陈卧龙
    
    文件名：TestForToken.CommonCS
    文件功能描述：Token相关操作
----------------------------------------------------------------*/
namespace Service
{
    public class CommonToken
    {
        private string secret = "123456";
            public string jiami() { 
            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();

            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
            var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);

             var payload = new Dictionary<string, object>
                       {
            {"name", "MrBug" },
            {"exp",secondsSinceEpoch+100 },
            {"jti","luozhipeng" }
                               };

             Console.WriteLine(secondsSinceEpoch);

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);
            return token;
        }

        public void jiemi(string token)
        { 
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);//token为之前生成的字符串
                //Console.WriteLine(json); 
            }
            catch (TokenExpiredException)
            {
                //Console.WriteLine("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                //Console.WriteLine("Token has invalid signature");
            }
        }
      }
}