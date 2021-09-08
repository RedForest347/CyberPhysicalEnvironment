using Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class Converter
    {

        #region ToDTO


        public static List<BusinessInfoDTO> ToDTO(List<BusinessInfo> businessInfos)
        {
            List<BusinessInfoDTO> businessInfoDTOs = new List<BusinessInfoDTO>();

            foreach (BusinessInfo info in businessInfos)
            {
                businessInfoDTOs.Add(ToDTO(info));
            }
            return businessInfoDTOs;
        }

        public static BusinessInfoDTO ToDTO(BusinessInfo businessInfo)
        {
            BusinessInfoDTO businessInfoDTO = new BusinessInfoDTO()
            {
                Id = businessInfo.Id,
                Name = businessInfo.Name,
                Director = businessInfo.Director,
                Status = businessInfo.Status,
                CreateTime = businessInfo.CreateTime

            };

            return businessInfoDTO;
        }



        #endregion


        #region FromDTO

        public static List<BusinessInfo> ToDTO(List<BusinessInfoDTO> businessInfoDTOs)
        {
            List<BusinessInfo> businessInfos = new List<BusinessInfo>();

            foreach (BusinessInfoDTO infoDTO in businessInfoDTOs)
            {
                businessInfos.Add(FromDTO(infoDTO));
            }
            return businessInfos;
        }


        public static BusinessInfo FromDTO(BusinessInfoDTO businessInfoDTO)
        {
            BusinessInfo businessInfo = new BusinessInfo()
            {
                Id = businessInfoDTO.Id,
                Name = businessInfoDTO.Name,
                Director = businessInfoDTO.Director,
                Status = businessInfoDTO.Status,
                CreateTime = businessInfoDTO.CreateTime

            };

            return businessInfo;
        }




        #endregion FromDTO
    }
}
