using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Controls.Sample.Core;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace MvvmCross.Controls.Sample.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        //protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        //{
        //    typeof(Android.Support.Design.Widget.NavigationView).Assembly,
        //    typeof(Android.Support.Design.Widget.FloatingActionButton).Assembly,
        //    typeof(Android.Support.V7.Widget.Toolbar).Assembly,
        //    typeof(Android.Support.V4.Widget.DrawerLayout).Assembly,
        //    typeof(Android.Support.V4.View.ViewPager).Assembly,
        //    typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly
        //};

        ///// <summary>
        ///// Fill the Binding Factory Registry with bindings from the support library.
        ///// </summary>
        //protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        //{
        //    MvxAppCompatSetupHelper.FillTargetFactories(registry);
        //    base.FillTargetFactories(registry);
        //}

        /// <summary>
        /// This is very important to override. The default view presenter does not know how to show fragments!
        /// </summary>
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
            return mvxFragmentsPresenter;
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
