using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TinyIoC;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;
using Avgangsalarm.Core.Services.Impl;
using Avgangsalarm.iOS.Services.Impl;
using Avgangsalarm.iOS.Services;
using MonoTouch.CoreLocation;

namespace Avgangsalarm.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		public override UIWindow Window { get; set; }
		private UIViewController _viewController;

		public override void FinishedLaunching (UIApplication application)
		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events

			// Set up Dependencies
			BuildUp ();

			_viewController = new PageViewController ();

			Window = new UIWindow (UIScreen.MainScreen.Bounds);
			Window.RootViewController = _viewController;
			Window.MakeKeyAndVisible ();
		}

		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application) { }
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application) { }
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
			ClearPreviousNotifications ();
		}
		// This method 	is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application) { }

		static void ClearPreviousNotifications ()
		{
			// Clear previous notifications
			UIApplication.SharedApplication.CancelAllLocalNotifications();
		}

		static void BuildUp ()
		{
			TinyIoCContainer.Current.Register (typeof(ILocationRepository), typeof(DummyLocationRepository)).AsSingleton ();
			TinyIoCContainer.Current.Register (typeof(IUpdateEngine), typeof(UpdateEngine)).AsSingleton ();
			TinyIoCContainer.Current.Register (typeof(IAppStateGateway), typeof(AppStateGateway)).AsSingleton ();
			TinyIoCContainer.Current.RegisterMultiple (typeof(IPublishUpdates), new[] {
				typeof(PublishUpdates)
			});
			TinyIoCContainer.Current.Register (typeof(IUpdateTrafikkdata), typeof(GetTrafikkData)).AsSingleton ();
			TinyIoCContainer.Current.Register (typeof(IMonitorGeoFences), typeof(MonitorGeoFences)).AsSingleton ();
			TinyIoCContainer.Current.Register (typeof(ITrafikkDataAdapter), typeof(TrafikkDataAdapter));
			TinyIoCContainer.Current.Register (typeof(ITrafikkdataDeserializer), typeof(TrafikkDataDeserializer)).AsSingleton ();
			TinyIoCContainer.Current.Register (typeof(ICLLocationManagerGateway), typeof(CLLocationManagerGateway)).AsSingleton ();
		}
	}
}

