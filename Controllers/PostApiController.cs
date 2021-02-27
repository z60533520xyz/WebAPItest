using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPItest.Data;
using WebAPItest.Models;

namespace WebAPItest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly WebAPItestContext _context;

        public PostApiController(WebAPItestContext context)
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
        public async Task<ActionResult<ApiResponse>> PostPayIdInformation(SendApiRequest ApiRequest)
        {
            ApiResponse apiResponse00 = new ApiResponse 
            {
                ResponseCode = "00",
                ResponseMsg = "成功"
            };
            /*
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

            ApiResponse apiResponse04 = new ApiResponse
            {
                ResponseCode = "04",
                ResponseMsg = "資料驗證錯誤"
            };

            ApiResponse apiResponse05 = new ApiResponse
            {
                ResponseCode = "05",
                ResponseMsg = "職業類別錯誤"
            };

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



            //資料驗證
            /*
            if (!IsGuid(ApiRequest.Guid)) return apiResponse02;
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

            }*/


            _context.SendApiRequest.Add(ApiRequest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PayIdInformationExists(ApiRequest.Guid))
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
        /*
        

        

        public bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[3,5]+\d{9}");
        }

        public bool IsIDcard(string str_idcard)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_idcard, @"(^\d{18}$)|(^\d{15}$)");
        }*/


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
