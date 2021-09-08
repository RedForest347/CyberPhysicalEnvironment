using Person.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person
{
    public class Converter
    {

        #region ToDTO


        public static List<PersonInfoDTO> ToDTO(List<PersonInfo> personInfos)
        {
            List<PersonInfoDTO> personInfoDTOs = new List<PersonInfoDTO>();

            foreach (PersonInfo info in personInfos)
            {
                personInfoDTOs.Add(ToDTO(info));
            }
            return personInfoDTOs;
        }

public static PersonInfoDTO ToDTO(PersonInfo personInfo)
        {
            PersonInfoDTO personInfoDTO = new PersonInfoDTO()
            {
                Id = personInfo.Id,
                Name = personInfo.Name,
                INN = personInfo.INN,
                Mail = personInfo.Mail,
                Pasport = personInfo.Pasport,
                Sex = personInfo.Sex,
                Status = personInfo.Status,
                CreateTime = personInfo.CreateTime

            };

            return personInfoDTO;
        }



        #endregion


        #region FromDTO

        public static List<PersonInfo> ToDTO(List<PersonInfoDTO> personInfoDTOs)
        {
            List<PersonInfo> personInfos = new List<PersonInfo>();

            foreach (PersonInfoDTO infoDTO in personInfoDTOs)
            {
                personInfos.Add(FromDTO(infoDTO));
            }
            return personInfos;
        }


        public static PersonInfo FromDTO(PersonInfoDTO personInfoDTO)
        {
            PersonInfo personInfo = new PersonInfo()
            {
                Id = personInfoDTO.Id,
                Name = personInfoDTO.Name,
                INN = personInfoDTO.INN,
                Mail = personInfoDTO.Mail,
                Pasport = personInfoDTO.Pasport,
                Sex = personInfoDTO.Sex,
                Status = personInfoDTO.Status,
                CreateTime = personInfoDTO.CreateTime

            };

            return personInfo;
        }




        #endregion FromDTO
    }
}
