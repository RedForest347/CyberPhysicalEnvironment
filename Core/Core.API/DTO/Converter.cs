using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.API
{
    public static class Converter
    {

        #region ToDTO

        public static AgentDTO ToDTO(Agent agent)
        {

            //это нужно для того, чтобы убрать рекурсию при пересылке (agent ссылается на link, link на agent и т.д.)
            for (int j = 0; j < agent.OutputLinks.Count; j++)
            {
                agent.OutputLinks[j].Agent1 = null;
                agent.OutputLinks[j].Agent2 = null;
            }
            for (int j = 0; j < agent.InputLinks.Count; j++)
            {
                agent.InputLinks[j].Agent1 = null;
                agent.InputLinks[j].Agent2 = null;
            }

            AgentDTO agentDTO = new()
            {
                Id = agent.Id,
                Name = agent.Name,
                Description = agent.Description,
                ImgURL = agent.ImgURL,
                Status = agent.Status,
                RegisterTime = agent.RegisterTime,
                OutputLinks = ToDTO(agent.OutputLinks),
                InputLinks = ToDTO(agent.InputLinks),
                AgentTypeDto = ToDTO(agent.AgentType),
                ObjectId = agent.ObjectId
            };
            return agentDTO;
        }

        public static List<AgentDTO> ToDTO(List<Agent> agentList)
        {
            List<AgentDTO> agentDTOs = new();

            foreach (Agent agent in agentList)
            {
                agentDTOs.Add(ToDTO(agent));
            }
            return agentDTOs;
        }

        public static LinkDTO ToDTO(Link link)
        {
            LinkDTO linkDTO = new()
            {
                Id = link.Id,
                Description = link.Description,
                Agent1Checked = link.Agent1Checked,
                Agent2Checked = link.Agent2Checked,
                RequestTime = link.RequestTime,
                CheckedTime = link.CheckedTime,
                CloseTime = link.CloseTime,
                ActiveLinkFlag = link.ActiveLinkFlag,
                Status = link.Status,
                Agent1Id = link.Agent1Id,
                Agent2Id = link.Agent2Id,                
                LinkTypeId = link.LinkTypeId,
                LinkType = ToDTO(link.LinkType)
            };



            return linkDTO;
        }

        public static List<LinkDTO> ToDTO(List<Link> linkLisl)
        {
            List<LinkDTO> agentDTOs = new();

            foreach (Link link in linkLisl)
            {
                agentDTOs.Add(ToDTO(link));
            }
            return agentDTOs;
        }

        public static AgentTypeDTO ToDTO(AgentType agentType)
        {
            AgentTypeDTO agentTypeDTO = new()
            {
                Id = agentType.Id,
                Code = agentType.Code,
                Name = agentType.Name,
                Description = agentType.Description
            };
            return agentTypeDTO;
        }

        public static List<AgentTypeDTO> ToDTO(List<AgentType> agentTypes)
        {
            List<AgentTypeDTO> agentTypeDTOs = new();

            foreach (AgentType type in agentTypes)
            {
                agentTypeDTOs.Add(ToDTO(type));
            }

            return agentTypeDTOs;
        }

        public static LinkTypeDTO ToDTO(LinkType linkType)
        {
            if (linkType == null)
                return null;
            LinkTypeDTO linkTypeDTO = new()
            {
                Id = linkType.Id,
                Code = linkType.Code,
                Name = linkType.Name,
                Description = linkType.Description
            };
            return linkTypeDTO;
        }

        public static List<LinkTypeDTO> ToDTO(List<LinkType> linkTypes)
        {
            List<LinkTypeDTO> linkTypeDTOs = new();

            foreach (LinkType type in linkTypes)
            {
                linkTypeDTOs.Add(ToDTO(type));
            }

            return linkTypeDTOs;
        }

        #endregion ToDTO


        #region FromDTO


        public static Agent FromDTO(AgentDTO agentDTO)
        {
            Agent agent = new()
            {
                Id = agentDTO.Id,
                Name = agentDTO.Name,
                Description = agentDTO.Description,
                ImgURL = agentDTO.ImgURL,
                Status = agentDTO.Status,
                RegisterTime = agentDTO.RegisterTime,
                OutputLinks = new List<Link>(),//FromDTO(agentDTO.OutputLinks),
                InputLinks = new List<Link>(),//FromDTO(agentDTO.InputLinks),
                AgentType = FromDTO(agentDTO.AgentTypeDto),
                AgentTypeId = agentDTO.AgentTypeDto.Id,
                ObjectId = agentDTO.ObjectId
            };

            return agent;
        }

        public static List<Agent> FromDTO(List<AgentDTO> agentDTOList)
        {
            List<Agent> agents = new();

            foreach (AgentDTO agentDTO in agentDTOList)
            {
                agents.Add(FromDTO(agentDTO));
            }
            return agents;
        }

        public static Link FromDTO(LinkDTO linkDTO)
        {
            Link link = new()
            {
                Id = linkDTO.Id,
                Description = linkDTO.Description,
                Agent1Checked = linkDTO.Agent1Checked,
                Agent2Checked = linkDTO.Agent2Checked,
                RequestTime = linkDTO.RequestTime,
                CheckedTime = linkDTO.CheckedTime,
                CloseTime = linkDTO.CloseTime,
                ActiveLinkFlag = linkDTO.ActiveLinkFlag,
                Status = linkDTO.Status,

                Agent1Id = linkDTO.Agent1Id,
                Agent2Id = linkDTO.Agent2Id,
                LinkTypeId = linkDTO.LinkTypeId,
                LinkType = FromDTO(linkDTO.LinkType)
            };
            return link;
        }

        public static List<Link> FromDTO(List<LinkDTO> linkDTOLisl)
        {
            List<Link> agents = new();

            foreach (LinkDTO linkDTO in linkDTOLisl)
            {
                agents.Add(FromDTO(linkDTO));
            }
            return agents;
        }

        public static AgentType FromDTO(AgentTypeDTO agentTypeDTO)
        {
            AgentType agentType = new()
            {
                Id = agentTypeDTO.Id,
                Code = agentTypeDTO.Code,
                Name = agentTypeDTO.Name,
                Description = agentTypeDTO.Description
            };
            return agentType;
        }

        public static List<AgentType> FromDTO(List<AgentTypeDTO> agentTypeDTOs)
        {
            List<AgentType> agentTypes = new();

            foreach (AgentTypeDTO typeDTO in agentTypeDTOs)
            {
                agentTypes.Add(FromDTO(typeDTO));
            }

            return agentTypes;
        }

        public static LinkType FromDTO(LinkTypeDTO linkTypeDTO)
        {
            LinkType linkType = new()
            {
                Id = linkTypeDTO.Id,
                Code = linkTypeDTO.Code,
                Name = linkTypeDTO.Name,
                Description = linkTypeDTO.Description
            };
            return linkType;
        }

        public static List<LinkType> FromDTO(List<LinkTypeDTO> linkTypeDTOs)
        {
            List<LinkType> linkTypes = new();

            foreach (LinkTypeDTO typeDTO in linkTypeDTOs)
            {
                linkTypes.Add(FromDTO(typeDTO));
            }

            return linkTypes;
        }


        #endregion FromDTO


    }
}
