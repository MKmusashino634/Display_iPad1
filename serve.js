var http = require('http');
var fs = require('fs');
/*
fsオブジェクト、、、非同期！
第一引数　対象のファイルパス
第二引数　エンコード
第三引数　コールバック函数指定

コールバック函数、、、
第一引数　エラーオブジェクト
第二引数　読み込んだデータ
*/

/*
//アクセスをipで制限、したかった、、、
var ips = [ '127.0.0.1' ];
server.use( ipfilter( ips, { mode: 'allow' } ) );
*/

var server = http.createServer(function(req, res){
    fs.readFile('./serve.html', 'utf-8', function(err, data){
        res.writeHead(200, {'Content-Type': 'text/html'});
        res.write(data);
        res.end();
    });
});

//listenportは3000
server.listen(3000);
console.log('　起動した！')
