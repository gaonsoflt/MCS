using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows;
using System.Collections;

namespace MCS.Model
{
    [DataContract]
    public class Equipment
    {
        public Equipment()
        {
        }

        public Equipment(long CompSeq, long toolSeq, String toolId, String toolName)
        {
            this.CompSeq = CompSeq;
            this.ToolSeq = toolSeq;
            this.ToolId = toolId;
            this.ToolName = toolName;
        }

        public ResourceDictionary ConvertResourceDic()
        {
            ResourceDictionary rd = new ResourceDictionary();
            rd.Add("CompSeq", this.CompSeq);
            rd.Add("ToolSeq", this.ToolSeq);
            rd.Add("ToolId", this.ToolId);
            rd.Add("ToolName", this.ToolName);
            rd.Add("ToolSpec", this.ToolSpec);
            rd.Add("ToolStatus", this.ToolStatus);
            rd.Add("ToolKind", this.ToolKind);
            rd.Add("ToolUsers", this.ToolUsers);
            rd.Add("ToolSerialNo", this.ToolSerialNo);
            return rd;
        }

        public static Equipment ConvertResourceToClass(ResourceDictionary rd)
        {
            Equipment eq = new Equipment();
            eq.CompSeq = (long)rd["CompSeq"];
            eq.ToolSeq = (long)rd["ToolSeq"];
            eq.ToolId = (String)rd["ToolId"];
            eq.ToolName = (String)rd["ToolName"];
            eq.ToolSpec = (String)rd["ToolSpec"];
            eq.ToolStatus = (long)rd["ToolStatus"];
            eq.ToolKind = (long)rd["ToolKind"];
            eq.ToolUsers = (String)rd["ToolUsers"];
            eq.ToolSerialNo = (String)rd["ToolSerialNo"];

            return eq;
        }

        [DataMember(Name = "compSeq")]
        public long CompSeq { get; set; }

        [DataMember(Name = "toolSeq")]
        public long ToolSeq { get; set; }

        [DataMember(Name = "toolId")]
        public String ToolId { get; set; }

        [DataMember(Name = "toolName")]
        public String ToolName { get; set; }

        [DataMember(Name = "toolSpec")]
        public String ToolSpec { get; set; }

        [DataMember(Name = "toolStatus")]
        public long? ToolStatus { get; set; }

        [DataMember(Name = "toolKind")]
        public long? ToolKind { get; set; }

        [DataMember(Name = "toolUsers")]
        public String ToolUsers { get; set; }

        [DataMember(Name = "toolSerialNo")]
        public String ToolSerialNo { get; set; }

        [DataMember(Name = "status")]
        public CodeMinor Status { get; set; }
    }
}
