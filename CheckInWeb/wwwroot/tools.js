function guid() {
	return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
		var r = Math.random() * 16 | 0,
			v = c == 'x' ? r : (r & 0x3 | 0x8);
		return v.toString(16);
	});
}

function getUserSession() {
	var storage = null;
	//var user = null;
	if (!window.localStorage) //判断浏览器是否支持localStorage
	{
		alert("对不起,你的手机不支持本软件.请检查权限");
		return;
	}
	storage = window.localStorage;
	if (!storage.getItem("CHeckInUserSession")) {
		//alert("不知道怎么读取不了");
		//alert("NEW"+guid());
		var uid = guid();
		storage.setItem("CHeckInUserSession", uid);
		//return storage.getItem("CHeckInUserSession");
	}
	//user.Session = storage.getItem("CHeckInUserSession");
	
	return storage.getItem("CHeckInUserSession");//user.Session;
}


