package crc643ad61ecf7ed4dd33;


public class OnboardingActivity_onBoardingFragment1
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TheAndroidPoc.TheView.OnboardingActivity+onBoardingFragment1, TheAndroidPoc", OnboardingActivity_onBoardingFragment1.class, __md_methods);
	}


	public OnboardingActivity_onBoardingFragment1 ()
	{
		super ();
		if (getClass () == OnboardingActivity_onBoardingFragment1.class)
			mono.android.TypeManager.Activate ("TheAndroidPoc.TheView.OnboardingActivity+onBoardingFragment1, TheAndroidPoc", "", this, new java.lang.Object[] {  });
	}

	public OnboardingActivity_onBoardingFragment1 (int p0)
	{
		super ();
		if (getClass () == OnboardingActivity_onBoardingFragment1.class)
			mono.android.TypeManager.Activate ("TheAndroidPoc.TheView.OnboardingActivity+onBoardingFragment1, TheAndroidPoc", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
