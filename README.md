# Display_iPad1
最終目標：iPad1(ios5.1.1)をwindows10のサブディスプレイにするdebianパッケージを作成する！

windows10とiPad1間で
1、無線LANでwindowsからsafariにhtmlファイルをサーブする。
2、通信の暗号化(TLS)、IPアドレスでの制限(LAN内接続のみに)
3、safariに画面を映すプログラムを考える。リアルタイム
4、以上に基づいたdebianパッケージを作成し、かつiPadのタッチパネルを使えるようにする。 
という三段階で作り上げていく。

今回利用するのはnode.jsである。
独学しながら一からプログラムの構築を目指す。

留意点
・ipad側はramが少ないので、プログラムは簡易化させなければならない。


発見

・無線でのデュアルディスプレイ技術はmiracastが存在するが、
残念ながら自分のパソコンは対応していなかった。
iPadももちろん対応していない。

・ディスプレイをHDMIケーブルで繋ぐと、
ディスプレイ情報「EDID」(Extended Display Identification Data)をパソコン側が要求する。
その機構が必要。或いは一旦iPad1専用で一度つくるか。

・リモート操作するVNC(Virtual Network Computing)という技術を知った。
しかし私はLAN内のみで良いので（セキュリティ等の技術が未熟なのもある）
プログラムを自作するに至る。

・通信にはSSL、VPNが有効か？
