# Rails vs Phoenix vs ASP.NET Core

Recently with a Rails application, I ran into a bit of a performance snafu. Out of curiosity, I thought I'd give a few other frameworks a spin.

## The application

I built a simple application that displays 100 or so user records as HTML. For each request, something like this query gets run:

```sql
select id, name, email, salt, crypted_password, time_zone, state, created_at, updated_at from users where state='active' order by email desc
```

The results are passed to a template (e.g. erb, eex, or cshtml) which then renders the result. Each project renders exactly the same markup and uses a layout, a view/template, and a partial to accomplish this.

I used Rails 4.2.6, ASP.NET Core 1.0, and Phoenix 1.2.1.

* Note, the database isn't included in the project, as I was connecting to an existing one. Also, the .NET project needs a file called `appsettings.json` which should look something like this:

``` 
{
  "ConnectionStrings": {
    "defaultConnection": "Data Source=localhost;User ID=dev;Password=somepassword;Database=db_name;"
  }
}
```

## The test

The test was run on my Macbook Pro, 2.6 GHz Intel Core i5, 8 GB 1600 MHz DDR3 usin Apache bench:

```
ab -n 1000 -c 100 -l http://127.0.0.1:4001/
```

I ran Phoenix using this set of commands:

```
MIX_ENV=prod mix compile.protocols
MIX_ENV=prod PORT=4001 elixir -pa _build/prod/consolidated -S mix phoenix.server
```

Rails was run like so:

```
rails s -e production
```

And for ASP.NET core:

```
ASPNETCORE_ENVIRONMENT=Production dotnet run
```

## The results


### 1000 requests processed in

```
ASP:      1.729 seconds
Phoenix:  2.942 seconds
Rails:    18.675 seconds
```

### Connection time

```
                        min  mean[+/-sd] median   max
ASP:      Total:         45  168  26.6    167     277
Phoenix:  Total:         25  288 157.1    248     744
Rails:    Total:         63 1780 301.8   1854    1968
```

### Average requests per second

```
ASP:      Requests per second:    578.53 [#/sec] (mean)
Phoenix:  Requests per second:    339.88 [#/sec] (mean)
Rails:    Requests per second:    53.55 [#/sec] (mean)
```

[Full, raw results here.](raw_results.md)

## Analysis

In running this test, I wanted to see how each framework fared out-of-the-box. Rails gurus can probably improve things, but the same can probably be said for Phoenix/.NET gurus.

Rails' performance is shockingly bad. I think it's because I didn't run it in cluster-mode, so it probably made use of only one core.

ASP.NET Core performed surprisingly well, roughly 10x the speed of Rails. Considering how new the tech is to the Mac/Linux world, this surprised me. A big part of the reason it performed so well was that I used Dapper as the ORM. I wrestled for a while with Entity Framework, but never got it connecting properly. It isn't really fair to compare Dapper to a full-fledged ORM like Ecto/ActiveRecord.

So, even though Phoenix didn't win out over all, I suspect that it really is the winner (or at least closer to parity with .NET than things appear). All other tests I've seen suggest that if my ASP.NET Core project was using Entity Framework, the numbers would drop significantly.


## Conclusion

First, don't decide your tech stack based on this. Second, while ASP.NET Core performed well, it wasn't as straightforward as Rails or Phoenix to get up and running. It felt rough around the edges. I'm not sure if it supports live reload/recompile on Mac. Also, F# support was less than stellar, and the only way I'd go back to .NET was if I was doing F# (or else working on a super awesome project like Midori).

Rails is... well, Rails. I'm not a big fan. Performance isn't good. And I just really don't like Ruby. I'd prefer C# to it.

Phoenix was the sweetspot, at least in this simple test (and a number of other projects I've tinkered with). Elixir and Phoenix:

- Are easy to set up
- Have good defaults
- Have good documentation
- Have a good repl and debugging
- Perform well enough
- Feel more complete than ASP.NET Core

And Elixir's a decent langauge. Its syntax does remind me of Ruby/VB.NET, which makes me sad. It's not statically typed, which also makes me sad. It doesn't have built-in currying, which makes me sadder still. But over all, I think it's what I'd choose for a new project on Mac. If I had a Windows dev box, I'd definitely do F# and either Suave or some flavor of ASP.NET.
