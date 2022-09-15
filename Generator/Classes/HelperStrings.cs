using System.Collections.Generic;

namespace Generator.Classes
{
    public class HelperStrings
    {
        public string Entity { get; set; }
        public string LEntity { get; set; }
        public string FEntity { get; set; }
        public string IRepo { get; set; }
        public string Repo { get; set; }
        public string Service { get; set; }
        public string Manager { get; set; }
        public string IRUsings { get; set; }
        public string RUsings { get; set; }
        public string SUsings { get; set; }
        public string MUsings { get; set; }
        public string IRNS { get; set; }
        public string RNS { get; set; }
        public string SNS { get; set; }
        public string MNS { get; set; }

        public HelperStrings(string entity, string daa, string dac, string ba, string bc, string dan, string bn)
        {
            Entity = GetEntity(entity);
            LEntity = Entity.Substring(0, 1).ToLower() + entity.Substring(1, entity.Length - 1);
            FEntity = "_" + LEntity;
            IRepo = "I" + Entity + "Repository";
            Repo = Entity + "Repository";
            Service = "I" + Entity + "Service";
            Manager = Entity + "Manager";

            IRUsings = CreateUsingStr(daa);
            RUsings = CreateUsingStr(dac);
            SUsings = CreateUsingStr(ba);
            MUsings = CreateUsingStr(bc);

            IRNS = dan.Split(',')[0];
            RNS = dan.Split(',')[1];
            SNS = bn.Split(',')[0];
            MNS = bn.Split(',')[1];
        }

        private string GetEntity(string entity)
        {
            var result = "";

            switch (entity.Split().Length)
            {
                case 1:
                    result = entity.Substring(0, 1).ToUpper() + entity.Substring(1, entity.Length - 1);
                    break;
                case 2:
                    result = entity.Split()[0].Substring(0, 1).ToUpper() + entity.Split()[0].Substring(1, entity.Split()[0].Length - 1) +
                        entity.Split()[1].Substring(0, 1).ToUpper() + entity.Split()[1].Substring(1, entity.Split()[1].Length - 1);
                    break;
                default:
                    break;
            }

            return result;
        }

        private string CreateUsingStr(string str)
        {
            var result = new List<string>();
            var arr = str.Split(',');

            foreach (var item in arr)
            {
                result.Add("using " + item + ";");
            }

            return string.Join("\n", result);
        }
    }
}
