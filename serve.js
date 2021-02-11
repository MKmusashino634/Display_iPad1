var http = require('http');
var fs = require('fs');

//urlの文字列解析
var url = require('url');

//クエリ文字列を扱う
var qs = require('querystring');


//予めすべてのファイルを読み込んで無駄をなくす。
var Page1 = fs.readFileSync('./serve1.html', 'utf-8');

//
var server = http.createServer(function(req, res){
    if(req.method == 'GET'){
        //urlをparseメソッドで分析してオブジェクト型の値として返す
        var urlParts = url.parse(req.url,true)
        console.log('---GET Request---');
        console.log('nameは' + urlParts.query.name);
        console.log('ageは' + urlParts.query.age);
    }
    else{
        var body = '';
        //データ受信後dataの登録
        req.on('data', function(data){
        //逐次結合
            body += data;
        });
        req.on('end', function(){
            var params = qs.parse(body);
            console.log('---POST Request---');
            console.log('nameは' + params.name);
            console.log('ageは' + params.age);
        });
    }
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.write(Page1);
    res.end();
    
});

//listenportは3000
server.listen(3000);
console.log('　起動した！')



/*
//アクセスをipで制限、したかった、、、
var ips = [ '127.0.0.1' ];
server.use( ipfilter( ips, { mode: 'allow' } ) );
※「use」がよくわからない状況。

追記、ファイアウォールでアプリケーションの通信を許可しなければ良い
と思ったが、windowsファイアウォールで設定するとLAN内でもできない。ループバックのみとなってしまう。
*/
