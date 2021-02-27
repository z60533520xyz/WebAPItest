using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPItest.Data;
using WebAPItest.Models;

namespace WebAPItest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly WebAPItestContext _context;

        public ApiController(WebAPItestContext context)
        {
            _context = context;
        }

        // GET: api/PayIdInformations1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayIdInformation>>> GetPayIdInformation()
        {
            /*
            var lambdjoin = _context.PayIdInformation.Join(_context.Product,
                payid => payid.Guid,
                prod => prod.Guid,
                (payid, prod) => new ApiRequest
                {
                    Agency = payid.Agency,
                    ProdCode = prod.ProdCode
                }
                )
                .AsNoTracking()
                .ToListAsync();

            return await lambdjoin;*/
                
            return await _context.PayIdInformation
                .Include(i => i.IdInformation)
                .Include(i => i.BenIdInformation)
                .Include(i => i.Product)
                
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/PayIdInformations1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayIdInformation>> GetPayIdInformation(string id)
        {
            var payIdInformation = await _context.PayIdInformation.FindAsync(id);

            if (payIdInformation == null)
            {
                return NotFound();
            }

            return payIdInformation;
        }



        // POST: api/PayIdInformations1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> PostPayIdInformation(ApiRequest ApiRequest)
        {
            ApiResponse apiResponse00 = new ApiResponse 
            {
                ResponseCode = "00",
                ResponseMsg = "成功"
            };

            ApiResponse apiResponse01 = new ApiResponse
            {
                ResponseCode = "01",
                ResponseMsg = "資料不完全"
            };

            ApiResponse apiResponse02 = new ApiResponse
            {
                ResponseCode = "02",
                ResponseMsg = "資料格式錯誤"
            };

            ApiResponse apiResponse03 = new ApiResponse
            {
                ResponseCode = "03",
                ResponseMsg = "商品代碼錯誤"
            };
            /*
            ApiResponse apiResponse04 = new ApiResponse
            {
                ResponseCode = "04",
                ResponseMsg = "資料驗證錯誤"
            };
            */
            ApiResponse apiResponse05 = new ApiResponse
            {
                ResponseCode = "05",
                ResponseMsg = "職業類別錯誤"
            };
            /*
            ApiResponse apiResponse06 = new ApiResponse
            {
                ResponseCode = "06",
                ResponseMsg = "總保費不符"
            };
            */
            ApiResponse apiResponse99 = new ApiResponse
            {
                ResponseCode = "99",
                ResponseMsg = "未知錯誤"
            };
            //必填項驗證
            if(ApiRequest.Agency == null || ApiRequest.Agency == "") return apiResponse01;
            if (ApiRequest.InsType == null || ApiRequest.InsType == "") return apiResponse01;
            if (ApiRequest.PayId == null || ApiRequest.PayId == "") return apiResponse01;
            if (ApiRequest.PayIdName == null || ApiRequest.PayIdName == "") return apiResponse01;
            if (ApiRequest.PayIdSex == null || ApiRequest.PayIdSex == "") return apiResponse01;
            if (ApiRequest.PayIdBirthday == null) return apiResponse01;
            if (ApiRequest.PayIdZipM == null || ApiRequest.PayIdZipM == "") return apiResponse01;
            if (ApiRequest.PayIdCityM == null || ApiRequest.PayIdCityM == "") return apiResponse01;
            if (ApiRequest.PayIdAreaM == null || ApiRequest.PayIdAreaM == "") return apiResponse01;
            if (ApiRequest.PayIdAddrM == null || ApiRequest.PayIdAddrM == "") return apiResponse01;
            if (ApiRequest.PayIdTelMv == null || ApiRequest.PayIdTelMv == "") return apiResponse01;
            if (ApiRequest.PayIdEmail == null || ApiRequest.PayIdEmail == "") return apiResponse01;
            if (ApiRequest.ApplyNo == null || ApiRequest.ApplyNo == "") return apiResponse01;
            if (ApiRequest.DueDt == null) return apiResponse01;
            if (ApiRequest.TotInv == null || ApiRequest.TotInv == "") return apiResponse01;
            if (ApiRequest.SendType == null || ApiRequest.SendType == "") return apiResponse01;
            if (ApiRequest.Location == null || ApiRequest.Location == "") return apiResponse01;
            if (ApiRequest.LocationCode == null || ApiRequest.LocationCode == "") return apiResponse01;
            if (ApiRequest.TravelDateFrom == null) return apiResponse01;
            if (ApiRequest.TravelDateEnd == null) return apiResponse01;
            if (ApiRequest.TravelDateHour == null || ApiRequest.TravelDateHour == "") return apiResponse01;
            if (ApiRequest.Id == null || ApiRequest.Id == "") return apiResponse01;
            if (ApiRequest.Idname == null || ApiRequest.Idname == "") return apiResponse01;
            if (ApiRequest.IdSex == null || ApiRequest.IdSex == "") return apiResponse01;
            if (ApiRequest.IdBirthday == null) return apiResponse01;
            if (ApiRequest.IdCityM == null || ApiRequest.IdCityM == "") return apiResponse01;
            if (ApiRequest.IdAreaM == null || ApiRequest.IdAreaM == "") return apiResponse01;
            if (ApiRequest.IdaddrM == null || ApiRequest.IdaddrM == "") return apiResponse01;
            if (ApiRequest.IdtelMv == null || ApiRequest.IdtelMv == "") return apiResponse01;
            if (ApiRequest.IdEmail == null || ApiRequest.IdEmail == "") return apiResponse01;
            if (ApiRequest.IdDeclarationOFGuardian == null || ApiRequest.IdDeclarationOFGuardian == "") return apiResponse01;
            if (ApiRequest.IdJobClass == 0) return apiResponse01;
            if (ApiRequest.Relationship == null || ApiRequest.Relationship == "") return apiResponse01;
            if (ApiRequest.ProdCode == null || ApiRequest.ProdCode == "") return apiResponse01;


            if (ApiRequest == null) return apiResponse01;
            if (ApiRequest == null) return apiResponse01;

            //資料驗證
            if (!IsID(ApiRequest.PayId)) return apiResponse02;
            if (!IsName(ApiRequest.PayIdName)) return apiResponse02;
            if (!IsSex(ApiRequest.PayIdSex)) return apiResponse02;
            if (!IsZip(ApiRequest.PayIdZipM)) return apiResponse02;
            if (!IsName(ApiRequest.PayIdCityM)) return apiResponse02;
            if (!IsName(ApiRequest.PayIdAreaM)) return apiResponse02;
            if (!IsAddr(ApiRequest.PayIdAddrM)) return apiResponse02;
            if (!IsMobile(ApiRequest.PayIdTelMv)) return apiResponse02;
            if (!IsEmail(ApiRequest.PayIdEmail)) return apiResponse02;
            if (!IsNum(ApiRequest.TotInv)) return apiResponse02;
            if (!IsApplyNo(ApiRequest.ApplyNo)) return apiResponse02;
            if (!IsE(ApiRequest.SendType)) return apiResponse02;
            if (!IsYorN(ApiRequest.Englishpolicy)) return apiResponse02;
            if (!IsHour(ApiRequest.TravelDateHour)) return apiResponse02;
            if (!IsID(ApiRequest.Id)) return apiResponse02;
            if (!IsName(ApiRequest.Idname)) return apiResponse02;
            if (!IsSex(ApiRequest.IdSex)) return apiResponse02;
            if (!IsName(ApiRequest.IdCityM)) return apiResponse02;
            if (!IsName(ApiRequest.IdAreaM)) return apiResponse02;
            if (!IsZip(ApiRequest.IdZipM)) return apiResponse02;
            if (!IsAddr(ApiRequest.IdaddrM)) return apiResponse02;
            if (!IsMobile(ApiRequest.IdtelMv)) return apiResponse02;
            if (!IsEmail(ApiRequest.IdEmail)) return apiResponse02;
            if (!IsYorN(ApiRequest.IdDeclarationOFGuardian)) return apiResponse02;
            if (ApiRequest.IdJobClass > 4 || ApiRequest.IdJobClass < 1) return apiResponse05;
            if (!IsRelationship(ApiRequest.Relationship)) return apiResponse02;
            if (!IsProdCode(ApiRequest.ProdCode)) return apiResponse03;
            if (ApiRequest.InsType == "ITP")
            {
                if (!IsLocation(ApiRequest.Location)) return apiResponse02;
                if (!IsLocationCode(ApiRequest.LocationCode)) return apiResponse02;
                if (ApiRequest.Relation != "1") return apiResponse02;
                if (!IsYorN(ApiRequest.PolicyPregnancy)) return apiResponse02;
                if (!IsYorN(ApiRequest.PolicyOtherMM)) return apiResponse02;
            }
            if (ApiRequest.Relationship != "0")
            {
                if (!IsID(ApiRequest.BenId)) return apiResponse02;
                if (!IsName(ApiRequest.BenName)) return apiResponse02;
                if (!IsZip(ApiRequest.BenZipM)) return apiResponse02;
                if (!IsAddr(ApiRequest.BenAddrM)) return apiResponse02;

            }

            //保費驗證
            //return apiResponse04;
            
            //取得guid
            string guid = Guid.NewGuid().ToString();

            SendApiRequest sendApiRequest = new SendApiRequest {
                Guid = guid,
                Agency = ApiRequest.Agency,
                Medium = ApiRequest.Medium,
                InsType = ApiRequest.InsType,
                PayId = ApiRequest.PayId,
                PayIdName = ApiRequest.PayIdName,
                PayIdSex = ApiRequest.PayIdSex,
                PayIdBirthday = ApiRequest.PayIdBirthday,
                PayIdZipM = ApiRequest.PayIdZipM,
                PayIdCityM = ApiRequest.PayIdCityM,
                PayIdAreaM = ApiRequest.PayIdAreaM,
                PayIdAddrM = ApiRequest.PayIdAddrM,
                PayIdTelH = ApiRequest.PayIdTelH,
                PayIdTelMv = ApiRequest.PayIdTelMv,
                PayIdEmail = ApiRequest.PayIdEmail,
                ApplyNo = ApiRequest.ApplyNo,
                DueDt = ApiRequest.DueDt,
                TotInv = ApiRequest.TotInv,
                SendType = ApiRequest.SendType,
                Englishpolicy = ApiRequest.Englishpolicy,
                Location = ApiRequest.Location,
                LocationCode = ApiRequest.LocationCode,
                TravelDateFrom = ApiRequest.TravelDateFrom,
                TravelDateEnd = ApiRequest.TravelDateEnd,
                TravelDateHour = ApiRequest.TravelDateHour,
                Id = ApiRequest.Id,
                EngName = ApiRequest.EngName,
                Passport = ApiRequest.Passport,
                Idname = ApiRequest.Idname,
                IdSex = ApiRequest.IdSex,
                IdBirthday = ApiRequest.IdBirthday,
                IdCityM = ApiRequest.IdCityM,
                IdAreaM = ApiRequest.IdAreaM,
                IdZipM = ApiRequest.IdZipM,
                IdaddrM = ApiRequest.IdaddrM,
                IdtelH = ApiRequest.IdtelH,
                IdtelMv = ApiRequest.IdtelMv,
                IdEmail = ApiRequest.IdEmail,
                Relation = ApiRequest.Relation,
                IdDeclarationOFGuardian = ApiRequest.IdDeclarationOFGuardian,
                IdJobClass = ApiRequest.IdJobClass,
                PolicyPregnancy = ApiRequest.PolicyPregnancy,
                PolicyOtherMM = ApiRequest.PolicyOtherMM,
                Relationship = ApiRequest.Relationship,
                BenId = ApiRequest.BenId,
                BenName = ApiRequest.BenName,
                BenPhone = ApiRequest.BenPhone,
                BenZipM = ApiRequest.BenZipM,
                BenAddrM = ApiRequest.BenAddrM,
                BenProportion = ApiRequest.BenProportion,
                BenSeq = ApiRequest.BenSeq,
                ProdCode = ApiRequest.ProdCode,
            };


            //保險公司API傳送
            ApiResponse fooAPIResult;
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    try
                    {
                        #region 呼叫遠端 Web API
                        string FooUrl = $"https://localhost:44301/api/PostApi";
                        HttpResponseMessage response = null;

                        #region  設定相關網址內容
                        var fooFullUrl = $"{FooUrl}";


                        // Content-Type 用於宣告遞送給對方的文件型態
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                        var fooJSON = JsonConvert.SerializeObject(sendApiRequest);
                        // https://msdn.microsoft.com/zh-tw/library/system.net.http.stringcontent(v=vs.110).aspx
                        using (var fooContent = new StringContent(fooJSON, Encoding.UTF8, "application/json"))
                        {
                            response = await client.PostAsync(fooFullUrl, fooContent);
                        }
                        #endregion
                        #endregion

                        #region 處理呼叫完成 Web API 之後的回報結果
                        if (response != null)
                        {
                            if (response.IsSuccessStatusCode == true)
                            {
                                // 取得呼叫完成 API 後的回報內容
                                String strResult = await response.Content.ReadAsStringAsync();
                                fooAPIResult = JsonConvert.DeserializeObject<ApiResponse>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                            }
                            else
                            {
                                fooAPIResult = new ApiResponse
                                {
                                    ResponseCode = "999",
                                    ResponseMsg = string.Format("Error Code:{0}, Error Message:{1}", response.StatusCode, response.RequestMessage)
                                };
                            }
                        }
                        else
                        {
                            fooAPIResult = new ApiResponse
                            {
                                ResponseCode = "998",
                                ResponseMsg = "應用程式呼叫 API 發生異常"
                            };
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        fooAPIResult = new ApiResponse
                        {
                            ResponseCode = "997",
                            ResponseMsg = ex.Message
                        };
                    }
                    if (fooAPIResult.ResponseCode != "00") return apiResponse99;
                }
            }

            

            //資料儲存
            PayIdInformation payIdInformation = new PayIdInformation {
                Guid = guid,
                Agency = ApiRequest.Agency,
                Medium = ApiRequest.Medium,
                InsType = ApiRequest.InsType,
                PayId = ApiRequest.PayId,
                PayIdName = ApiRequest.PayIdName,
                PayIdSex = ApiRequest.PayIdSex,
                PayIdBirthday = ApiRequest.PayIdBirthday,
                PayIdZipM = ApiRequest.PayIdZipM,
                PayIdCityM = ApiRequest.PayIdCityM,
                PayIdAreaM = ApiRequest.PayIdAreaM,
                PayIdAddrM = ApiRequest.PayIdAddrM,
                PayIdTelH = ApiRequest.PayIdTelH,
                PayIdTelMv = ApiRequest.PayIdTelMv,
                PayIdEmail = ApiRequest.PayIdEmail,
                ApplyNo = ApiRequest.ApplyNo,
                DueDt = ApiRequest.DueDt,
                TotInv = ApiRequest.TotInv,
                SendType = ApiRequest.SendType,
                Englishpolicy = ApiRequest.Englishpolicy,
                Location = ApiRequest.Location,
                LocationCode = ApiRequest.LocationCode,
                TravelDateFrom = ApiRequest.TravelDateFrom,
                TravelDateEnd = ApiRequest.TravelDateEnd,
                TravelDateHour = ApiRequest.TravelDateHour
            };

            IdInformation idInformation = new IdInformation
            {
                Id = ApiRequest.Id,
                EngName = ApiRequest.EngName,
                Passport = ApiRequest.Passport,
                Idname = ApiRequest.Idname,
                IdSex = ApiRequest.IdSex,
                IdBirthday = ApiRequest.IdBirthday,
                IdCityM = ApiRequest.IdCityM,
                IdAreaM = ApiRequest.IdAreaM,
                IdZipM = ApiRequest.IdZipM,
                IdaddrM = ApiRequest.IdaddrM,
                IdtelH = ApiRequest.IdtelH,
                IdtelMv = ApiRequest.IdtelMv,
                IdEmail = ApiRequest.IdEmail,
                Relation = ApiRequest.Relation,
                IdDeclarationOFGuardian = ApiRequest.IdDeclarationOFGuardian,
                IdJobClass = ApiRequest.IdJobClass,
                PolicyPregnancy = ApiRequest.PolicyPregnancy,
                PolicyOtherMM = ApiRequest.PolicyOtherMM,
                Guid = guid,
            };

            BenIdInformation benIdInformation = new BenIdInformation
            {
                Relationship = ApiRequest.Relationship,
                BenId = ApiRequest.BenId,
                BenName = ApiRequest.BenName,
                BenPhone = ApiRequest.BenPhone,
                BenZipM = ApiRequest.BenZipM,
                BenAddrM = ApiRequest.BenAddrM,
                BenProportion = ApiRequest.BenProportion,
                BenSeq = ApiRequest.BenSeq,
                Guid = guid
            };

            Product product = new Product
            {
                ProdCode = ApiRequest.ProdCode,
                Guid = guid
            };

            _context.PayIdInformation.Add(payIdInformation);
            _context.IdInformation.Add(idInformation);
            _context.BenIdInformation.Add(benIdInformation);
            _context.Product.Add(product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PayIdInformationExists(payIdInformation.Guid))
                {
                    //return Conflict();
                    return apiResponse99;
                }
                else
                {
                    throw;   
                }
            }



            return apiResponse00;
        }

      

        public bool IsGuid(string str_Guid)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Guid, @"^([a-z]|\d){8}-([a-z]|\d){4}-([a-z]|\d){4}-([a-z]|\d){4}-([a-z]|\d){12}$");
        }

        public bool IsEmail(string str_Email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool IsE(string str_E)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_E, @"^E{1}$");
        }

        public bool IsYorN(string str_YorN)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_YorN, @"^(Y|N){1}$");
        }

        public bool IsSex(string str_Sex)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Sex, @"^(F|M){1}$");
        }

        public bool IsID(string str_ID)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_ID, @"^[A-Z]{1}[1-2]{1}[0-9]{8}$");
        }

        public bool IsZip(string str_Zip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Zip, @"^[0-9]{3,5}$");
        }

        public bool IsHour(string str_Hour)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Hour, @"^[0-2]{1}[0-9]{1}$") && int.Parse(str_Hour) < 24;
        }

        public bool IsName(string str_Name)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Name, @"^[\u4e00-\u9fa5]+$");
        }

        public bool IsAddr(string str_Addr)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Addr, @"^[\u4e00-\u9fa5_a-zA-Z0-9]+$");
        }

        public bool IsMobile(string str_Mobile)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Mobile, @"^0{1}9{1}[0-9]{8}$");
        }

        public bool IsNum(string str_Num)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Num, @"^[0-9]+$");
        }

        public bool IsApplyNo(string str_ApplyNo)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_ApplyNo, @"^2{1}[0-1]{1}[0-9]{10}$");
        }

        public bool IsLocation(string str_Location)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Location, @"^[0-2]{1}$");
        }

        public bool IsLocationCode(string str_LocationCode)
        {
            List<string> locationCode = new List<string>{"TW", "JP" ,"US"}; 
            foreach(string code in locationCode)
            {
                if (str_LocationCode == code) return true;
            }
            return false;
        }

        public bool IsRelationship(string str_Relationship)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Relationship, @"^[0-3]{1}$");
        }

        private bool PayIdInformationExists(string id)
        {
            return _context.PayIdInformation.Any(e => e.Guid == id);
        }

        public bool IsProdCode(string str_ProdCode)
        {
            List<string> locationCode = new List<string> { "robins-moto100" };
            foreach (string code in locationCode)
            {
                if (str_ProdCode == code) return true;
            }
            return false;
        }
    }
}
