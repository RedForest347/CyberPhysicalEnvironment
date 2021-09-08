using Machinery.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Machinery
{
    public class Converter
    {

        #region ToDTO


        public static List<MachineryInfoDTO> ToDTO(List<MachineryInfo> machineryInfos)
        {
            List<MachineryInfoDTO> machineryInfoDTOs = new List<MachineryInfoDTO>();

            foreach (MachineryInfo info in machineryInfos)
            {
                machineryInfoDTOs.Add(ToDTO(info));
            }
            return machineryInfoDTOs;
        }

public static MachineryInfoDTO ToDTO(MachineryInfo machineryInfo)
        {
            MachineryInfoDTO machineryInfoDTO = new MachineryInfoDTO()
            {
                Id = machineryInfo.Id,
                Name = machineryInfo.Name,
                Code = machineryInfo.Code,
                EndWorkTime = machineryInfo.EndWorkTime,
                LastVerificationTime = machineryInfo.LastVerificationTime,
                VerificationTime = machineryInfo.VerificationTime,
                Status = machineryInfo.Status,
                CreateTime = machineryInfo.CreateTime

            };

            return machineryInfoDTO;
        }



        #endregion


        #region FromDTO

        public static List<MachineryInfo> ToDTO(List<MachineryInfoDTO> machineryInfoDTOs)
        {
            List<MachineryInfo> machineryInfos = new List<MachineryInfo>();

            foreach (MachineryInfoDTO infoDTO in machineryInfoDTOs)
            {
                machineryInfos.Add(FromDTO(infoDTO));
            }
            return machineryInfos;
        }


        public static MachineryInfo FromDTO(MachineryInfoDTO machineryInfoDTO)
        {
            MachineryInfo machineryInfo = new MachineryInfo()
            {
                Id = machineryInfoDTO.Id,
                Name = machineryInfoDTO.Name,
                Code = machineryInfoDTO.Code,
                EndWorkTime = machineryInfoDTO.EndWorkTime,
                LastVerificationTime = machineryInfoDTO.LastVerificationTime,
                VerificationTime = machineryInfoDTO.VerificationTime,
                Status = machineryInfoDTO.Status,
                CreateTime = machineryInfoDTO.CreateTime

            };

            return machineryInfo;
        }




        #endregion FromDTO
    }
}
