package crc643ad61ecf7ed4dd33;


public class OnboardingActivity
	extends android.support.v4.app.FragmentActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TheAndroidPoc.TheView.OnboardingActivity, TheAndroidPoc", OnboardingActivity.class, __md_methods);
	}


	public OnboardingActivity ()
	{
		super ();
		if (getClass () == OnboardingActivity.class)
			mono.android.TypeManager.Activate ("TheAndroidPoc.TheView.OnboardingActivity, TheAndroidPoc", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
