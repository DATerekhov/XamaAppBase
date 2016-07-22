package md599d61569676417f6c3a8db52929596ee;


public class CardioExerciseActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("XamaAndrTest.CardioExerciseActivity, XamaAndrTest, Version=1.0.6047.35213, Culture=neutral, PublicKeyToken=null", CardioExerciseActivity.class, __md_methods);
	}


	public CardioExerciseActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CardioExerciseActivity.class)
			mono.android.TypeManager.Activate ("XamaAndrTest.CardioExerciseActivity, XamaAndrTest, Version=1.0.6047.35213, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
