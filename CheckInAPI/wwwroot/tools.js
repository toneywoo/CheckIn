function guid() {
	return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
		var r = Math.random() * 16 | 0,
			v = c == 'x' ? r : (r & 0x3 | 0x8);
		return v.toString(16);
	});
}

function getUrlPath() {
	return window.location.protocol + "//" + window.location.host + "" ;//+ window.location.pathname.replace("","");
	

}

function getQueryVariable(variable) {
	var query = window.location.search.substring(1);
	var vars = query.split("&");
	for (var i = 0; i < vars.length; i++) {
		var pair = vars[i].split("=");
		if (pair[0] == variable) {
			return pair[1];
		}
	}
	return (false);
}
var funDownload = function (content, filename) {
    // 创建隐藏的可下载链接
    var eleLink = document.createElement('a');
    eleLink.download = filename;
    eleLink.style.display = 'none';
    // 字符内容转变成blob地址
    var blob = new Blob([content]);
    eleLink.href = URL.createObjectURL(blob);
    // 触发点击
    document.body.appendChild(eleLink);
    eleLink.click();
    // 然后移除
    document.body.removeChild(eleLink);
};

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

	return storage.getItem("CHeckInUserSession"); //user.Session;
}

function getUser() {
	var user = {
		session: '',
		Name: '',
		Phone: '',
		Description: ''
	};
	user.session = getUserSession();
	user.Name = window.localStorage.getItem("Name");
	user.Phone = window.localStorage.getItem("Phone");
	user.Description = window.localStorage.getItem("Description");
	return user;
}
