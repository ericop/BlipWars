using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts
{
    class BuildPerTick
    {
        public int Attackers { get; set; }
        public int Workers { get; set; }
        public int Snipers { get; set; }
        public int TaskMasters { get; set; }

        public string CurrentCommand()
        {
            var props = this.GetType().GetProperties();
            var sb = new StringBuilder();
            sb.AppendLine("Current Command:");
            foreach (var p in props)
            {
                sb.AppendLine(p.GetValue(this, null) + "x " + p.Name);
            }
            return sb.ToString();
        }

        public string AiCommand()
        {
            var props = this.GetType().GetProperties();
            var sb = new StringBuilder();
            sb.AppendLine("AI Command:");
            foreach (var p in props)
            {
                sb.AppendLine(p.GetValue(this, null) + "x " + p.Name);
            }
            return sb.ToString();
        }


        public string PropertyList()
        {
            var props = this.GetType().GetProperties();
            var sb = new StringBuilder();
            foreach (var p in props)
            {
                sb.AppendLine(p.Name + ": " + p.GetValue(this, null));
            }
            return sb.ToString();
        }
    }
}
