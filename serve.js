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

追記、ファイアウォールでアプリケーションの通信を許可しなければ良い！
*/

var server = http.createServer(function(req, res){
    var target = '';
    switch(req.url){
        case '/':
        case '/Display_iPad1-page1':
            target = './serve1.html';
            break;
        case '/Display_iPad1-page2':
            target = './serve2.html';
            break;
        default:
            res.writeHead(200, {'Content-Type': 'text/plain'});
            res.end('bad request');
            return;
    }
    fs.readFile(target, 'utf-8', function(err, data){
        res.writeHead(200, {'Content-Type': 'text/html'});
        res.write(data);
        res.end();
    });
});

//listenportは3000
server.listen(3000);
console.log('　起動した！')
