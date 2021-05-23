package crc649a404c15c798b166;


public class Toast_Android
	extends android.widget.Toast
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TareasXamarin.Droid.Toast_Android, TareasXamarin.Android", Toast_Android.class, __md_methods);
	}


	public Toast_Android (android.content.Context p0)
	{
		super (p0);
		if (getClass () == Toast_Android.class)
			mono.android.TypeManager.Activate ("TareasXamarin.Droid.Toast_Android, TareasXamarin.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
