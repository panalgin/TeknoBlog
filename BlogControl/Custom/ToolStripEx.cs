using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogControl.Custom
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ToolStrip))]
    public class ToolStripEx : ToolStrip
    {
        public ToolStripEx()
        {
            this.Renderer = new ToolStripExProfessionalRenderer();
            this.RenderMode = ToolStripRenderMode.Custom;
        }
    }

    public class ToolStripExSystemRenderer : ToolStripSystemRenderer
    {
        public ToolStripExSystemRenderer() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);
        }
    }

    class ToolStripExProfessionalRenderer : ToolStripProfessionalRenderer
    {
        public ToolStripExProfessionalRenderer()
            : base(new ExProfessionalColorTable())
        {

        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Don't draw a border
        }
    }

    class ExProfessionalColorTable : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin
        {
            get { return SystemColors.Control; }
        }

        public override Color ToolStripGradientMiddle
        {
            get { return SystemColors.Control; }
        }

        public override Color ToolStripGradientEnd
        {
            get { return SystemColors.Control; }
        }
    }
}
