using Smod2;
using Smod2.Attributes;

namespace KillerCount.OnLoad
{
    class OnLoad
    {
        [PluginDetails(author = "Miiers", name = "KillerCount", description = "", id = "mumu", version = "1.0")]
        internal class @event : Plugin
        {
            public override void OnDisable()
            {
                base.Info("KillerCount is not run now");
            }

            public override void OnEnable()
            {
                base.Info("KillerCount 已启动");
                base.Info("插件出现问题请联系QQ:1029482435 或 寻找喵呜服主");
            }

            public override void Register()
            {
                this.AddEventHandlers(new OnRun.OnRun(this));
                this.AddConfig(new Smod2.Config.ConfigSetting("kc_save", true, true, ""));
            }
        }
    }
}