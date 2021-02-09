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
※「use」がよくわからない状況。

追記、ファイアウォールでアプリケーションの通信を許可しなければ良い
と思ったが、windowsファイアウォールで設定するとLAN内でもできない。ループバックのみとなってしまう。
*/

//予めすべてのファイルを読み込んで無駄をなくす。
var Page1 = fs.readFileSync('./serve1.html', 'utf-8')
var Page2 = fs.readFileSync('./serve2.html', 'utf-8')

var server = http.createServer(function(req, res){
    var target = '';
    switch(req.url){
        case '/':
        case '/Display_iPad1-page1':
            target = Page1;
            break;
        case '/Display_iPad1-page2':
            target = Page2;
            break;
        default:
            res.writeHead(200, {'Content-Type': 'text/plain'});
            res.end('bad request');
            return;
    }
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.write(target);
    res.end();
    
});

//listenportは3000
server.listen(3000);
console.log('　起動した！')
