function submitBanner() {

    var xhr = new XMLHttpRequest();
    var urlRequest = 'http://localhost:50350/Views/Home/Cadastro.aspx';
    xhr.open('POST', urlRequest, true);
    xhr.setRequestHeader('content-type', 'application/x-www-form-urlencoded');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    var obj = { login: "Knautiluz", pass: "@M4st3r" };
    xhr.send(JSON.stringify(obj));

}