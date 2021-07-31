var http = require('http');
var fs = require('fs');

//urlの文字列解析
var url = require('url');

var server = http.createServer(function(req, res){
        //urlをparseメソッドで分析してオブジェクト型の値として返す
        var urlParts = url.parse(req.url);
        var path = url.parse(req.url);
        var stream = fs.createReadStream(path);
        stream.on('data', function(data){
            res.write(data);
        });
        stream.on('end', function(data){
            res.end();
        });
    
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
