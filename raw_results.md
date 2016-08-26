# The raw results

Rails:

```
Server Software:        WEBrick/1.3.1
Server Hostname:        127.0.0.1
Server Port:            3000

Document Path:          /
Document Length:        Variable

Concurrency Level:      100
Time taken for tests:   18.675 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      8649000 bytes
HTML transferred:       8200000 bytes
Requests per second:    53.55 [#/sec] (mean)
Time per request:       1867.543 [ms] (mean)
Time per request:       18.675 [ms] (mean, across all concurrent requests)
Transfer rate:          452.27 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   1.0      0       6
Processing:    57 1780 302.8   1854    1967
Waiting:       53 1779 302.8   1854    1967
Total:         63 1780 301.8   1854    1968

Percentage of the requests served within a certain time (ms)
  50%   1854
  66%   1874
  75%   1887
  80%   1892
  90%   1903
  95%   1911
  98%   1917
  99%   1922
 100%   1968 (longest request)
 ```

Phoenix:

```

Concurrency Level:      100
Time taken for tests:   2.942 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      8522000 bytes
HTML transferred:       8193000 bytes
Requests per second:    339.88 [#/sec] (mean)
Time per request:       294.222 [ms] (mean)
Time per request:       2.942 [ms] (mean, across all concurrent requests)
Transfer rate:          2828.57 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    2   4.2      0      39
Processing:    25  286 156.7    247     726
Waiting:       25  285 156.3    247     726
Total:         25  288 157.1    248     744

Percentage of the requests served within a certain time (ms)
  50%    248
  66%    349
  75%    420
  80%    457
  90%    512
  95%    559
  98%    614
  99%    648
 100%    744 (longest request)
 ```

 ASP.NET Core

```
Server Software:        Kestrel
Server Hostname:        127.0.0.1
Server Port:            5000

Document Path:          /users
Document Length:        Variable

Concurrency Level:      100
Time taken for tests:   1.729 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      7582000 bytes
HTML transferred:       7469000 bytes
Requests per second:    578.53 [#/sec] (mean)
Time per request:       172.852 [ms] (mean)
Time per request:       1.729 [ms] (mean, across all concurrent requests)
Transfer rate:          4283.60 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    2   6.9      0      70
Processing:    43  166  27.9    166     277
Waiting:       43  165  28.9    165     277
Total:         45  168  26.6    167     277

Percentage of the requests served within a certain time (ms)
  50%    167
  66%    175
  75%    182
  80%    186
  90%    199
  95%    207
  98%    223
  99%    234
 100%    277 (longest request)
 ```
