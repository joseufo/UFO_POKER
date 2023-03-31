(window.webpackJsonp = window.webpackJsonp || []).push([
  [0],
  {
    106: function (e, t, n) {
      "use strict";
      n.r(t),
        n.d(t, "Card", function () {
          return c;
        });
      var a = n(64),
        r = n(121),
        i = ["2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"],
        suit = ["s", "c", "d", "h"],
        rank = {
          2: "Two",
          3: "Trey",
          4: "Four",
          5: "Five",
          6: "Six",
          7: "Seven",
          8: "Eight",
          9: "Nine",
          T: "Ten",
          J: "Jack",
          Q: "Queen",
          K: "King",
          A: "Ace",
        },
        c = (function () {
          function e(t, n) {
            if ((Object(a.a)(this, e), !i.includes(t)))
              throw Error("Invalid rank!");
            if (!suit.includes(n)) throw Error("Invalid suit!");
            (this.rank = t), (this.suit = n);
          }
          return (
            Object(r.a)(e, null, [
              {
                key: "getNameByRank",
                value: function (e) {
                  return rank[e];
                },
              },
            ]),
            e
          );
        })();
    },
    186: function (e, t, n) {
      e.exports = n.p + "static/media/pokerlistingscomlogo.108300e7.svg";
    },
    274: function (e, t, n) {
      "use strict";
      n.r(t),
        n.d(t, "Hand", function () {
          return i;
        });
      var a = n(64),
        r = n(106).Card,
        i = function e(t) {
          if ((Object(a.a)(this, e), !Array.isArray(t)))
            throw Error("Cards must be Array");
          if (t.length < 2) throw Error("Hand must have more than two cards");
          t.forEach(function (e) {
            if (!(e instanceof r))
              throw Error("Hand array elements must be Card object");
          }),
            (this.cards = t);
        };
    },
    353: function (e, t, n) {
      var a = n(106).Card,
        r = n(274).Hand,
        i = n(606).Board,
        s = n(607).Player,
        o = n(932).Game;
      e.exports = {
        Card: a,
        Hand: r,
        Board: i,
        Player: s,
        Game: o,
      };
    },
    363: function (e, t, n) {
      e.exports = n(931);
    },
    606: function (e, t, n) {
      "use strict";
      n.r(t),
        n.d(t, "Board", function () {
          return i;
        });
      var a = n(64),
        r = n(106).Card,
        i = function e(t) {
          if ((Object(a.a)(this, e), !Array.isArray(t)))
            throw Error("Cards must be Array");
          t.forEach(function (e) {
            if (!(e instanceof r))
              throw Error("Card array elements must be Card object");
          }),
            (this.cards = t);
        };
    },
    607: function (e, t, n) {
      "use strict";
      n.r(t),
        n.d(t, "Player", function () {
          return i;
        });
      var a = n(64),
        r = n(274).Hand,
        i = function e(t, n) {
          if ((Object(a.a)(this, e), !(n instanceof r)))
            throw Error("Player hand must be Hand object");
          (this.id = t), (this.hand = n);
        };
    },
    609: function (e, t) {
      e.exports.find = function e(t, n) {
        var a, r, i, s, o;
        if (n > t.length || n <= 0) return [];
        if (n === t.length) return [t];
        if (1 === n) {
          for (i = [], a = 0; a < t.length; a++) i.push([t[a]]);
          return i;
        }
        for (i = [], a = 0; a < t.length - n + 1; a++)
          for (
            s = t.slice(a, a + 1), o = e(t.slice(a + 1), n - 1), r = 0;
            r < o.length;
            r++
          )
            i.push(s.concat(o[r]));
        return i;
      };
    },
    626: function (e, t, n) {},
    865: function (e, t, n) {},
    866: function (e, t, n) {},
    867: function (e, t, n) {},
    869: function (e, t, n) {},
    870: function (e, t, n) {},
    871: function (e, t, n) {},
    872: function (e, t, n) {},
    876: function (e, t, n) {},
    878: function (e, t, n) {},
    879: function (e, t, n) {},
    881: function (e, t, n) {},
    882: function (e, t, n) {},
    883: function (e, t, n) {
      var a = {
        "./cards/ranks/black/ace.svg": 884,
        "./cards/ranks/black/eight.svg": 885,
        "./cards/ranks/black/five.svg": 886,
        "./cards/ranks/black/four.svg": 887,
        "./cards/ranks/black/jack.svg": 888,
        "./cards/ranks/black/king.svg": 889,
        "./cards/ranks/black/nine.svg": 890,
        "./cards/ranks/black/queen.svg": 891,
        "./cards/ranks/black/seven.svg": 892,
        "./cards/ranks/black/six.svg": 893,
        "./cards/ranks/black/ten.svg": 894,
        "./cards/ranks/black/three.svg": 895,
        "./cards/ranks/black/two.svg": 896,
        "./cards/ranks/red/ace.svg": 897,
        "./cards/ranks/red/eight.svg": 898,
        "./cards/ranks/red/five.svg": 899,
        "./cards/ranks/red/four.svg": 900,
        "./cards/ranks/red/jack.svg": 901,
        "./cards/ranks/red/king.svg": 902,
        "./cards/ranks/red/nine.svg": 903,
        "./cards/ranks/red/queen.svg": 904,
        "./cards/ranks/red/seven.svg": 905,
        "./cards/ranks/red/six.svg": 906,
        "./cards/ranks/red/ten.svg": 907,
        "./cards/ranks/red/three.svg": 908,
        "./cards/ranks/red/two.svg": 909,
        "./cards/shirt.png": 910,
        "./cards/shirt.svg": 911,
        "./cards/suits/club.svg": 912,
        "./cards/suits/diamond.svg": 913,
        "./cards/suits/heart.svg": 914,
        "./cards/suits/spade.svg": 915,
        "./caret-down.svg": 916,
        "./caret-left.svg": 917,
        "./caret-right.svg": 918,
        "./logoSpade.svg": 919,
        "./logoTableSpade.svg": 920,
        "./personBlack.svg": 921,
        "./personGrow.svg": 922,
        "./personWhite.svg": 923,
        "./poc-logoTableSpade.svg": 924,
        "./poc-pokerlistings.svg": 925,
        "./poc-table-logo.svg": 926,
        "./poc-table.png": 927,
        "./pokerlistings.svg": 928,
        "./pokerlistingscomlogo.svg": 186,
        "./questionMark.svg": 929,
        "./table2.png": 930,
      };

      function r(e) {
        var t = i(e);
        return n(t);
      }

      function i(e) {
        if (!n.o(a, e)) {
          var t = new Error("Cannot find module '" + e + "'");
          throw ((t.code = "MODULE_NOT_FOUND"), t);
        }
        return a[e];
      }
      (r.keys = function () {
        return Object.keys(a);
      }),
        (r.resolve = i),
        (e.exports = r),
        (r.id = 883);
    },
    884: function (e, t, n) {
      e.exports = n.p + "static/media/ace.c2187385.svg";
    },
    885: function (e, t, n) {
      e.exports = n.p + "static/media/eight.0d9f74a4.svg";
    },
    886: function (e, t, n) {
      e.exports = n.p + "static/media/five.0b96be04.svg";
    },
    887: function (e, t, n) {
      e.exports = n.p + "static/media/four.2107bb1a.svg";
    },
    888: function (e, t, n) {
      e.exports = n.p + "static/media/jack.6a8662f6.svg";
    },
    889: function (e, t, n) {
      e.exports = n.p + "static/media/king.92e7c21b.svg";
    },
    890: function (e, t, n) {
      e.exports = n.p + "static/media/nine.dc5aa927.svg";
    },
    891: function (e, t, n) {
      e.exports = n.p + "static/media/queen.3b1853dd.svg";
    },
    892: function (e, t, n) {
      e.exports = n.p + "static/media/seven.992e9098.svg";
    },
    893: function (e, t, n) {
      e.exports = n.p + "static/media/six.e7813684.svg";
    },
    894: function (e, t, n) {
      e.exports = n.p + "static/media/ten.a98da1ca.svg";
    },
    895: function (e, t, n) {
      e.exports = n.p + "static/media/three.84e7c6ae.svg";
    },
    896: function (e, t, n) {
      e.exports = n.p + "static/media/two.5144a116.svg";
    },
    897: function (e, t, n) {
      e.exports = n.p + "static/media/ace.f5e03550.svg";
    },
    898: function (e, t, n) {
      e.exports = n.p + "static/media/eight.334c2283.svg";
    },
    899: function (e, t, n) {
      e.exports = n.p + "static/media/five.bc6a9bd6.svg";
    },
    900: function (e, t, n) {
      e.exports = n.p + "static/media/four.31361fd5.svg";
    },
    901: function (e, t, n) {
      e.exports = n.p + "static/media/jack.29fc05ba.svg";
    },
    902: function (e, t, n) {
      e.exports = n.p + "static/media/king.b3521162.svg";
    },
    903: function (e, t, n) {
      e.exports = n.p + "static/media/nine.7caaa155.svg";
    },
    904: function (e, t, n) {
      e.exports = n.p + "static/media/queen.8f7842c9.svg";
    },
    905: function (e, t, n) {
      e.exports = n.p + "static/media/seven.dcba4e7b.svg";
    },
    906: function (e, t, n) {
      e.exports = n.p + "static/media/six.46db48fa.svg";
    },
    907: function (e, t, n) {
      e.exports = n.p + "static/media/ten.ea581b05.svg";
    },
    908: function (e, t, n) {
      e.exports = n.p + "static/media/three.47790b2c.svg";
    },
    909: function (e, t, n) {
      e.exports = n.p + "static/media/two.e91e7d82.svg";
    },
    910: function (e, t) {
      e.exports =
        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEYAAABwCAMAAACU0/YGAAAAAXNSR0IB2cksfwAAAAlwSFlzAAALEwAACxMBAJqcGAAAAi5QTFRFAAAA////////////////////////////////////////7e3urq+zjo+ViouRj5CWx8fLKiw4FRck7u7vMjRAUFFbYWNrZWZuY2VtTU9ZJig0Jyk18/P0lZacXF5nMzRAGRsoGBonICIuHyEuFxkmGhwpJSczUFJbMjM/lJWbenyDNzhDLS86Pj9KQ0RPOjtGPD5JPT9KIyUxLC05KCo2KSs3JCYyJSYzHiAsLC46JCUyMzVAOz1IOTtGMDI9XV9oFhglZWZvdXd+IyQxKSo2MTM+HB4rHyAtKSs2LS87NjhDHiAtPkBKTU5YIiQxSEpUeHqBGx0qODpFKCk1GRsnIiQwJic0ISIvISMwPT5JHR8rSElTSUtVQUJNKyw4Gx0pP0FLISMvPD1IHh8sHyEtODlER0lTMjQ/REVQLzE8NjdDQkROQkNONDZBLjA8SkxWQUNNNTdCP0BLQ0VPLzA8UVNdFxklFhgkMTI+MzVBLS46QEJMU1VeKy05QEFMGBkmNzlEHR8sNTZCTlBZHB4qQkRPGhwoICEuLC45QUNOJyg0GBomKis3LjA7PT9JPD5IMDE9IiMwMTM/OjxHOTpFIyUyLi87ODpERUZRREZQNDVBOzxHKy04GxwpJyg1HR4rKCo1JCYzNzlDKiw3MTI9UlRdeHmAlpecdHV8ycnMXV5nwMDEkZKYUVJcbW52o6Spd3h/ZGZuWVpkWltkkJGX////////////////////JYRsCgAAALp0Uk5TAJPh+f8I6ATjfPz//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////2LP6st2YSoSCQAAEL1JREFUeJytmel/28h5x52Nm+ZqGzx1L6CtMMQMqtaQRYIgSIggMq3FCQ9VLSjRhtjKAiQqMiWRFSlXtsxSJlWuJHd1xbR3KcvObnbT+z6Stv9dh95sGsd4s9mdF6SEz4Mv53ieZ37PzJUrV6584a0vXv2Z2xff+sKVUfu5L/3sjI/bl36eY778WSlXr375ypWvfHbK1atfufLW54F568pXPw/MV6988tfXvv4Lv/gp2y99/WufvP0J5hsC/AxN+MbrmF++9iu/+mufsv36b4gg/eZrmN/67TGZ01FE+fhnMOYfBP/kL2My+kQ/8UT9nXH43dcwv3ed22kTNyajMZEb6PG4DrpqkP9/ByXMJKQsYTT4qbSdiToE5G/S338N8wcRwHYmQjHcjI0BEhCKI0mN6CBPO9msxACUbxk5yCOiK7RQKPJeqTM6/OHsH72G+WMX0texmBfyOi1JRGTMIMniHH8d5rPlV725dTvJMZ7iOeMfG+KFyp+If/pTmNQivpPiP5JUl3waTyZ55wlCihiARUiu7ALiTN3Q899ahvgKN9TF6uq338BomqeTvBDHAlkLQOFTXcxH79rZGJhQW1/d2KyrfMaZhxvSjwwNUvqzNzD1wEAGAkVXvJzBB2FGt5wIBWgqGFoc4BqT285oylddg3xsqN/78zcw6aKwI+zAirqiSzkoR22Vwv2KIZsPQN3FCZ2vtPuwPY5gEv3YMP8Xb2A6t9QVRdAtkkzlxV1fBahIHdOconuPukFENfNzPQA6HZ1OR/SRocAN9//yDcxSBlmIeKgfh9jbDykNHoquextb0BBmQJCDPhPz5R2gzo1x/CNDHH1zimFXYlZSFwUk+FWIaDo+ONRFkiD9uxo+QqIeIXg2792HqccRMjKMo3EzBENLGmIegyMbzx9ZZfOvEpJZfaez4/nXaBwVTelYECTtYR/YRAJzQ9roQAgG6Em7oWmnTVysdXSXjqIokrgFk+SsMiUES3yOqXvTyoqAoq10/jzKvTIMA2qzo9nrtPodjgC5WnVHoSk+YOVV/k2LAW8uLJWTnJPVpn0cilHgiQ7JUoTSR9LqoDB24jTtaFqMynHSFDuTfmb3xKk/bV0LKFXmBxjGyjgVgvHgDLs+Uh5psQRzn0lHCZ1RV/PvUPY0I+KVO5qVUA9ppLGc9EBfA1HDStigsA2TAdz0LTSdsR1N097NbKeL2Gn7s+7aTPeelh8rTfjnjNRLB5DW5ffC58Z7Iq5B4ylR94bDVtME6DNXKpRmHpTqZyol7ADcRubG8MLBul9GEzQWjukkJuS1BFptP8NQEQvPcS/bwMQv7J8V0tDLathY5NHpqvuL3pJ9RxD2V0Ix9fF8utPbs+fBQyIm6iUSGY5Gco8H8okFEknGlhgWkQLe20fIVqN5IxQTnXmSZhsx7AHPLNy6s/sOdG9KC0RsyTxLzMdk0PkMpgiThnFkrxWyYRh64bcOWqsqpGBF4K6l0AkiOl4LqchYRTHUmSYMkCEs8fxlb1R7ra1MGKY4HAb1/ADrMHbWru0XFci/iM1PsL5lQFNQ008JIcebaTMmI0VY82ljuBiGUYfrzKdRYNVV8NbwJEXm3dwL4b6FpJ67iewbgPSuEwAPWnK7dvQQbw1xCKYzrDYlWMCKbFPVgY4qzG7gS+rdJIhnC212k+iFir6stWWsBDXclu8Nw7w4m0E+3ZmUUzC7UHJFswGJrGlRiypYKso+zCCIIq+YeAmQmhbweWfpIixRNDu5WpF1jnlwAQqYEYd9vc74VqUgIkD3dt6E6EGPzz1WwHbN6iQsGyGYyWD1UMqh2IGCiZ4lz1OwSFtwjEBk0Hmnc1x2YHyunJ1nWLlVwOepNhq3QjAx6kNHx1PLcoo73833gNikSy2Q+f5gKuW1RxlItefncRyCzZ6rmvVAckIwPrQBI9WaWdRhKdGdh2K3mGai3GEGLprFJthciMTKiKrbmX2B4oYYGQvDoFMwsgrg5OlWSR3pgfrheFWP9Fk/6N/qFWCZPyvuLg5tI1D3Yy+FTrEeNijZPjG5IkEYd1MAEaTv99LkuywJeuXQq+7DGRT5dpfOv7JZWRCsYiEEs0w3MhBkbiyLiE5iUyC9AT4DC0WMCHTQ9Dn3TF1whYfgOtHoCQiLQjEd1hvYEpCv9JVNialWRbgNG3it2NPep+S4CnbVXIOcQKO0OJOJVIQTNEzONkIw3UpJNB1JkRyf0TMwBDgX5EskJ3NiH6x9sD3kVPmuag0jSd1twWJRkkIwtYh2MuWIfBnbBMd2cN5Fe25kRuITW+0uoEQGJJVaJto/U44/qMTwBnbCgkE/cvfchVk2ez2KUeulSTo75VMy34hmNt6uPRJ9uaKC+O5U/0FttUzWBGn8IDRR4OtsPFO83u3cqpOlVsWDeRVmJ8zRBoXZ6kJ/3gQkdSwleG5mmmJ1i7FCaPZ7jnDDf553nmIvV6PvLk4kGeCTrfdq2cuNBqXV9ONopB+lEWddNU82dKSGJ9HZ72F4KR6ZFORNx0oj1+4Bq7f4VlNo3+IO0yDe6UGai7mqVdBkQPs4fNesw2yPh+UsTGoLsQMhYT4Jtvg+gzAgZ5225g0xEUc+oSkZDiLF+XsQtt3VsBFRJP2DO/S8NScND4TjYGGARqJTqOlYyrSJISU6eGFAsTY128H3iKKHpS0uZSEnd/D0dmFzfsAHtbyZIvmRbMc6V5ZD58A7JQ8ymQJ1DXfWzUI+DMMIzInkIfIumqK/Kp8NYxkNczFriIaEFQH8/cwD9mzYTbbSUIzTLsIMhWF0BTJ9+rK91a/N7dXRhwtbrqcjCTOCE1hg2hFAcLpXrYk3DKDCTaIHIVPM4kz0+rYbVUti/3nwZAwzGwRk7PDe6MxT1KAOUpTsN4oFqRQUHRJnSfVNDA8cEEDdTqhK+yKhiGJsLAN5vucKvZcWGH3B3RzUD4TK5dvZoBwtUX0FoPYmxgugb0DXTug5v2CnmNjazUAcJJxHXI6qfSPY3Nglins6LJDDvWZR0YGEpHRs5AX04hxH1ShCWmJtF7/0QSR6X8nnSZAKPPMB3X/MMt7SpDko0w+xyp+Haj/o25S67W2OaTtorNs1mQF3+GADcSeP0jyxniwuAuncmAPKnoxeCMEIOjT773dw+cJPD1fJ3jBmPAVewHiGqICou1svrpeYM2yoi1mI5KCRwkKYF2dZyqE58hEVN9QFNEiDazcFLAorO0jJ67B8IUAwMR+N7V3Sqtir0i5nh/UGmmj2ls7Ll87bXm6IcpJZuy4BEwVBRWi9tMwEVRN72/58v6aXj6jkoVAvXmnc1ys799/vQzcRa6FcQjqBxKo5quykzeuyzQzVkdAEQ2KVa4oKbUKYF4NTxKCOXZcouNtaLo2CiZGuvDtc3hz6AcCagII2KUSARjq5Kmc/6IfmG14rrBYkvWHLnmZRcz976FJn76RKSVnL6Lif3rD16hhSrK6pOusIBffCMD0n9Z6mX27sT6+xqq0fwryJ7GN60NG0Ksi2uGSCfMsyU2b9WT1dLUeROwhdcPHmU7et9IPlGEGtagXl6KpEnZnaVHm362JbPZRw7tpKf72TJt8pBJaFVsPmpl5cMwzN8NT0BsYzFOVdrrZX8xQv3YeiTeQWFXS+/6HBZGXuo2+tVu7O18phm6+8XJ7TjEBM24w1QTBgQHINSDqd2kd4qQQN0c2yFxIbv1hKJiOXdFie64Rg2rCdI77CgqGJGmKq00OXdA+ZOcpw1aJPIodNeCG4kxB5LDCl2UkNJT1M30zgTRvY4MaljnuX9LvCTmS8WOLxndA7WK3qJ1xFiZZckyBiX0Zr1FnoRHbfxFAfXWY7eCQ6qlEuQHSYPZlNV1TPZe97KbW3BntwiIDaEiCuXcqX0sPbzdBBtWjaFgJz7O7FpcVLN+WavlvUmQKzjIkr49B6dWBxOlwVA7FbfyQIkTCZ5MMWpS9FbdN2wRVaDPqlw+bSHOgSF6N6NcvLLTBLhxivDZvTRcAN6dm1EMyCOyCWTmsDXFVBFi+BxpYW7p+8Og1SK2Kn2oTegBIkgOijiug1FS1sijNiQxJUt0UUKqsOtYtwifxHhgt5BnnqzE4LkE7pWUxQqpOVv+8u0m7YgjfTkaYnZyXMhR8pEysBjrEmVUTA0JNgBheqfDH73qgUov6jW4fX6UaYTHK2UWykR1NwvtU98KQXkC+VbYgjFQtuqoA2AM5YKlBHnLyK67fE4c0QzIvhneMTGkOpYpd28ryaVsULEk32RHBzsB+xokx5iox17UNesolWf5EOhiy0ENp7tLy0ACzyBHINZYJi6bIe+DjBjkjQxf4CxmZ6PwUZrjpU7UOjPBzSEExquFhTBj6vEdejw7TfU6AxlYmkHVQz51uuZUQRI9qNtNlGhGmrJby34YcWiduZWDV+MceFTvGOKPOvAXWjclSookuxkoGHOS4W5MTzMiGwsPDIGfjd0OwXu9T9fvbxS48vBaoUYTonU/Xpy4manZej/SU0Mf+qZCWMTbeIMVFPn4di1hvOVJtpCwgrS5LsGk3g/tu5rg+bsr1CP/IiGT4sla9k+VSeaqVilhSKsQyb6VuqNDE1OhHLOtTMHnFpe2HWF2vQa5y7qdN8GYPyfICsBXlcrKdCMeW1yFNQ/KwrtYYXaZ77wX2W9sXj9tsvugtHvZHqym8OhyXdLTVRxYaJ8MMFXmiMTwN22gZVtHp99XKw/24ZGe39aOMRMZrRzGR7a80o4pOWCPSSkUwoRgcuGCeYCuT8tC5VXYp6+vRaO+pieBhdK4+Ol3iZ+aI7mKYGvHsH1BPkhWAIOCZU7PcpL229h93YjeGF35XQwM2zBVJei97dG0SXn+cYkB1eSgNkyxAuTJ41O1pmklYT5R8fFFOsryOhgemPHzApAtXtmpaI0fC5IZlSRxcW1nGq8UCY7TFWLEv5HKybM1SyPihXGeuVj7/vKFB9PCZ54mmNhmFe+mWkJwNs2XhHzatTYkIyK2DMp+52sMaj2uQSQ31oETAHlVeGwodhMbWsK3GFeXkm+BEgCSF1oOQ0kkA3F2tYk/O5COklah7Q2l3ysSFpxN/ERK6TOC7PrWALn0bzGIiUN8kB7sCu7nP1RA70/EmZwtIgds4NPSOFLRRymJm/pa5MJZnAVbY2ZbSOHgG9bVm5Mm7TrKoIHUfiDogamUpBUVd0blhJKmtvHq3Wi8KOxVWk2telBMjOllPk/+nIaEBllRo9vi4pbZnnvgESduIfG4Yc9KYDsZ9YAT2ieMej+pI47ZjFV36Z+90ZoT3pWntyVORDaUkkOW4YBJ7z129ghHzKWLp3ovLkW0gh8aMKDylxPBrltTkIrRt+wZC51+gf3WxIqSRpnKj34yj604fgf+OSLSImd2DH0N0otRg74Z4XvLqkiGNc4UNSdARSgOLf28MGN0SG55XCTpNKyBNqQgpFI67oKeJLqV8eFVM72VGw8wKnnwALGUrZ2cevDF2/8m3x9XuGv40AjG8JFLAZ4zuThVCHSt9J8WzHOtlG8h3emUAXQOjvGIQW2lxmYtEfXVf83WuYvy/xHww+HG5P3htFV49LYWAJiVeZbNRGz8SEAvPTH4xuMMzM8EYmzzPzP9B/fA1z9Z9eXeV8uqb+89m/XH0dc/Vf/+3TXiz9+3/8539d/WnMZ2ufF+ZzugL8nC4kf/B5YH5w5coPPzvlh6O74//+rJT/eXUF/Vkvsv+XI/4Pbhem+XYCnXQAAAAASUVORK5CYII=";
    },
    911: function (e, t, n) {
      e.exports = n.p + "static/media/shirt.00a37696.svg";
    },
    912: function (e, t, n) {
      e.exports = n.p + "static/media/club.e005cd8c.svg";
    },
    913: function (e, t, n) {
      e.exports = n.p + "static/media/diamond.64dbd537.svg";
    },
    914: function (e, t, n) {
      e.exports = n.p + "static/media/heart.f6713ec2.svg";
    },
    915: function (e, t, n) {
      e.exports = n.p + "static/media/spade.0b020c20.svg";
    },
    916: function (e, t, n) {
      e.exports = n.p + "static/media/caret-down.a82e0187.svg";
    },
    917: function (e, t, n) {
      e.exports = n.p + "static/media/caret-left.93169868.svg";
    },
    918: function (e, t, n) {
      e.exports = n.p + "static/media/caret-right.4f09fa74.svg";
    },
    919: function (e, t, n) {
      e.exports = n.p + "static/media/logoSpade.ddfe498b.svg";
    },
    920: function (e, t, n) {
      e.exports = n.p + "static/media/logoTableSpade.eab70640.svg";
    },
    921: function (e, t, n) {
      e.exports = n.p + "static/media/personBlack.53241f01.svg";
    },
    922: function (e, t, n) {
      e.exports = n.p + "static/media/personGrow.1bd95538.svg";
    },
    923: function (e, t, n) {
      e.exports = n.p + "static/media/personWhite.cf59a9ba.svg";
    },
    924: function (e, t, n) {
      e.exports = n.p + "static/media/poc-logoTableSpade.d2ace1b1.svg";
    },
    925: function (e, t, n) {
      e.exports = n.p + "static/media/poc-pokerlistings.edb343be.svg";
    },
    926: function (e, t, n) {
      e.exports = n.p + "static/media/poc-table-logo.857e3cd6.svg";
    },
    927: function (e, t, n) {
      e.exports = n.p + "static/media/poc-table.2f998eec.png";
    },
    928: function (e, t, n) {
      e.exports = n.p + "static/media/pokerlistings.da7c40db.svg";
    },
    929: function (e, t, n) {
      e.exports = n.p + "static/media/questionMark.1376b030.svg";
    },
    930: function (e, t, n) {
      e.exports = n.p + "static/media/table2.17c39d15.png";
    },
    931: function (e, t, n) {
      "use strict";
      n.r(t);
      var a,
        r = n(0),
        i = n.n(r),
        s = n(183),
        o = n.n(s),
        c = n(122),
        l = n(69),
        d = n(360),
        u = n(29),
        m = n(352),
        calcOdds = "CALCULATE_ODDS",
        toggCard = "TOGGLE_CARD_ACTIVE",
        removCard = "REMOVE_CARD",
        v = "TOGGLE_HINT",
        b = "CLOSE_HINT",
        g = "SHOW_HINT",
        y = "SET_CHOSEN_CARD",
        setWinner = "SET_WINNER",
        C = "SET_BOARD_PLAYERS",
        O = "SET_BOARD_CAROUSEL",
        cardRank = {
          RANK_TWO: "2",
          RANK_THREE: "3",
          RANK_FOUR: "4",
          RANK_FIVE: "5",
          RANK_SIX: "6",
          RANK_SEVEN: "7",
          RANK_EIGHT: "8",
          RANK_NINE: "9",
          RANK_TEN: "T",
          RANK_JACK: "J",
          RANK_QUEEN: "Q",
          RANK_KING: "K",
          RANK_ACE: "A",
        },
        cardSuit = {
          SUIT_CLUB: "c",
          SUIT_DIAMOND: "d",
          SUIT_HEART: "h",
          SUIT_SPADE: "s",
        },
        gameType = {
          omaha: "Omaha Hi",
          texas: "Texas Holdem",
        },
        w = {
          texas: "holdem",
          texasHL: "holdem8",
          omaha: "omaha",
          omahaHL: "omaha8",
          stud: "7stud",
          studHL: "7stud8",
          studHLNQ: "7stud8nq",
          razz: "razz",
        },
        A =
          (n(372),
          n(373),
          n(374),
          n(375),
          n(376),
          n(377),
          n(378),
          n(379),
          n(380),
          n(381),
          n(382),
          n(383),
          n(384),
          n(385),
          n(386),
          n(387),
          n(388),
          n(389),
          n(390),
          n(391),
          n(392),
          n(393),
          n(394),
          n(395),
          n(397),
          n(399),
          n(400),
          n(250),
          n(402),
          n(403),
          n(404),
          n(405),
          n(406),
          n(407),
          n(408),
          n(409),
          n(410),
          n(411),
          n(412),
          n(413),
          n(414),
          n(415),
          n(416),
          n(417),
          n(418),
          n(419),
          n(420),
          n(422),
          n(423),
          n(425),
          n(426),
          n(427),
          n(428),
          n(429),
          n(430),
          n(431),
          n(432),
          n(433),
          n(434),
          n(435),
          n(436),
          n(437),
          n(439),
          n(440),
          n(441),
          n(442),
          n(443),
          n(444),
          n(445),
          n(446),
          n(447),
          n(448),
          n(449),
          n(450),
          n(451),
          n(453),
          n(454),
          n(455),
          n(456),
          n(457),
          n(458),
          n(459),
          n(460),
          n(461),
          n(462),
          n(464),
          n(465),
          n(466),
          n(467),
          n(468),
          n(469),
          n(470),
          n(471),
          n(472),
          n(473),
          n(474),
          n(475),
          n(476),
          n(477),
          n(478),
          n(479),
          n(480),
          n(481),
          n(482),
          n(483),
          n(484),
          n(485),
          n(487),
          n(488),
          n(489),
          n(490),
          n(494),
          n(495),
          n(496),
          n(498),
          n(499),
          n(500),
          n(501),
          n(502),
          n(503),
          n(504),
          n(505),
          n(506),
          n(507),
          n(508),
          n(509),
          n(510),
          n(511),
          n(512),
          n(513),
          n(514),
          n(515),
          n(516),
          n(517),
          n(518),
          n(519),
          n(520),
          n(521),
          n(522),
          n(523),
          n(524),
          n(525),
          n(526),
          n(527),
          n(528),
          n(529),
          n(530),
          n(531),
          n(532),
          n(533),
          n(534),
          n(535),
          n(536),
          n(537),
          n(538),
          n(539),
          n(540),
          n(541),
          n(542),
          n(543),
          n(544),
          n(545),
          n(546),
          n(547),
          n(548),
          n(549),
          n(550),
          n(551),
          n(552),
          n(553),
          n(554),
          n(555),
          n(556),
          n(557),
          n(558),
          n(559),
          n(560),
          n(561),
          n(562),
          n(563),
          n(564),
          n(565),
          n(566),
          n(567),
          n(568),
          n(569),
          n(570),
          n(571),
          n(572),
          n(573),
          n(574),
          n(575),
          n(576),
          n(577),
          n(578),
          n(579),
          {
            calculators: [
              {
                name: "Which Hand Wins Calculator",
                id: "whw",
                games: [
                  {
                    name: "Texas Hold'em",
                    id: "texas",
                    rules: {
                      maxPlayers: 8,
                      minPlayers: 2,
                      numberOfCardsInHand: 2,
                      numberOfCardsOnBoard: 5,
                      minNumberOfFilledCardsInHandForCosting: 2,
                      minNumberOfFilledCardsOnBoardForCosting: 5,
                    },
                    active: !0,
                  },
                  {
                    name: "Omaha",
                    id: "omaha",
                    rules: {
                      maxPlayers: 8,
                      minPlayers: 2,
                      numberOfCardsInHand: 4,
                      numberOfCardsOnBoard: 5,
                      minNumberOfFilledCardsInHandForCosting: 4,
                      minNumberOfFilledCardsOnBoardForCosting: 5,
                    },
                  },
                ],
              },
              {
                name: "Poker Odds Calculator",
                id: "poc",
                games: [
                  {
                    name: "Texas Holdem",
                    id: "texas",
                    rules: {
                      maxPlayers: 7,
                      minPlayers: 2,
                      numberOfCardsInHand: 2,
                      numberOfCardsOnBoard: 4,
                      minNumberOfFilledCardsInHandForCosting: 2,
                      minNumberOfFilledCardsOnBoardForCosting: 0,
                    },
                    active: !0,
                  },
                  {
                    name: "Texas Holdem Hi/Lo",
                    id: "texasHL",
                    rules: {
                      maxPlayers: 7,
                      minPlayers: 2,
                      numberOfCardsInHand: 2,
                      numberOfCardsOnBoard: 4,
                      minNumberOfFilledCardsInHandForCosting: 2,
                      minNumberOfFilledCardsOnBoardForCosting: 0,
                      hiLo: !0,
                    },
                  },
                  {
                    name: "Omaha",
                    id: "omaha",
                    rules: {
                      maxPlayers: 7,
                      minPlayers: 2,
                      numberOfCardsInHand: 4,
                      numberOfCardsOnBoard: 4,
                      minNumberOfFilledCardsInHandForCosting: 4,
                      minNumberOfFilledCardsOnBoardForCosting: 0,
                    },
                  },
                  {
                    name: "Omaha Hi/Lo",
                    id: "omahaHL",
                    rules: {
                      maxPlayers: 7,
                      minPlayers: 2,
                      numberOfCardsInHand: 4,
                      numberOfCardsOnBoard: 4,
                      minNumberOfFilledCardsInHandForCosting: 4,
                      minNumberOfFilledCardsOnBoardForCosting: 0,
                      hiLo: !0,
                    },
                  },
                  {
                    name: "7-Card Stud",
                    id: "stud",
                    rules: {
                      maxPlayers: 5,
                      minPlayers: 2,
                      numberOfCardsInHand: 6,
                      numberOfCardsOnBoard: 0,
                      minNumberOfFilledCardsInHandForCosting: 3,
                      minNumberOfFilledCardsOnBoardForCosting: 0,
                      noCommunityCards: !0,
                    },
                  },
                  {
                    name: "7-Card Stud Hi/Lo",
                    id: "studHL",
                    rules: {
                      maxPlayers: 5,
                      minPlayers: 2,
                      numberOfCardsInHand: 6,
                      numberOfCardsOnBoard: 0,
                      minNumberOfFilledCardsInHandForCosting: 3,
                      minNumberOfFilledCardsOnBoardForCosting: 0,
                      noCommunityCards: !0,
                      hiLo: !0,
                    },
                  },
                  {
                    name: "7-Card Stud Hi/Lo No Qualifier",
                    id: "studHLNQ",
                    rules: {
                      maxPlayers: 5,
                      minPlayers: 2,
                      numberOfCardsInHand: 6,
                      numberOfCardsOnBoard: 0,
                      minNumberOfFilledCardsInHandForCosting: 3,
                      minNumberOfFilledCardsOnBoardForCosting: 0,
                      noCommunityCards: !0,
                      hiLo: !0,
                    },
                  },
                  {
                    name: "Razz",
                    id: "razz",
                    rules: {
                      maxPlayers: 5,
                      minPlayers: 2,
                      numberOfCardsInHand: 6,
                      numberOfCardsOnBoard: 0,
                      minNumberOfFilledCardsInHandForCosting: 3,
                      minNumberOfFilledCardsOnBoardForCosting: 0,
                      noCommunityCards: !0,
                    },
                  },
                ],
              },
            ],
          }),
        R = "error",
        F = function (e, t) {
          for (var n = [], a = 0; a < t; ++a) n.push(!1);
          return {
            id: e,
            playerName: "Player " + e,
            hand: n,
          };
        },
        T = function (e, t, n) {
          var a = e.length,
            r = Math.abs(t),
            i = 0;
          if (t > 0) for (; i < r; ++i) e.push(F(a + i + 1, n));
          else e.splice(a + t, r);
          return e;
        },
        I = function (e, t, n) {
          for (var a, r = [], i = 0; i < t - 1; ++i)
            r.push({
              name: (a = e + i) + " players",
              id: a,
              active: !1,
            });
          return (
            n <= t && n >= e
              ? (r.find(function (e) {
                  return e.id === n;
                }).active = !0)
              : (r[0].active = !0),
            r
          );
        },
        H = function (e, t, n) {
          return {
            players: T([], e, t),
            table: n,
            winner: !1,
            activeField: {
              type: "player",
              id: 0,
              card: {
                type: "player",
                id: 0,
              },
            },
          };
        },
        j = function () {
          return A.calculators.find(function (e) {
            return (
              e.id ===
              (Object({
                NODE_ENV: "production",
                PUBLIC_URL: ".",
              }).REACT_APP_CALCULATOR_TYPE || "whw")
            );
          });
        },
        x = function (e) {
          var t = {};
          switch (e) {
            case 5:
              (t.flop = [!1, !1, !1]), (t.turn = !1), (t.river = !1);
              break;
            case 4:
              (t.flop = [!1, !1, !1]), (t.turn = !1);
              break;
            case 3:
              t.flop = [!1, !1, !1];
              break;
            case 2:
              t.flop = [!1, !1];
              break;
            case 1:
              t.flop = [!1];
          }
          return t;
        },
        P = j().games.find(function (e) {
          return e.active;
        }).rules,
        L = x(P.numberOfCardsOnBoard),
        J = H(P.minPlayers, P.numberOfCardsInHand, L),
        K = I(P.minPlayers, P.maxPlayers),
        W = {
          id: j().id,
          rules: j().games,
          players: K,
        },
        B = {
          ranks: [
            {
              label: "2",
              name: "two",
              id: "RANK_TWO",
            },
            {
              label: "3",
              name: "three",
              id: "RANK_THREE",
            },
            {
              label: "4",
              name: "four",
              id: "RANK_FOUR",
            },
            {
              label: "5",
              name: "five",
              id: "RANK_FIVE",
            },
            {
              label: "6",
              name: "six",
              id: "RANK_SIX",
            },
            {
              label: "7",
              name: "seven",
              id: "RANK_SEVEN",
            },
            {
              label: "8",
              name: "eight",
              id: "RANK_EIGHT",
            },
            {
              label: "9",
              name: "nine",
              id: "RANK_NINE",
            },
            {
              label: "10",
              name: "ten",
              id: "RANK_TEN",
            },
            {
              label: "J",
              name: "jack",
              id: "RANK_JACK",
            },
            {
              label: "Q",
              name: "queen",
              id: "RANK_QUEEN",
            },
            {
              label: "K",
              name: "king",
              id: "RANK_KING",
            },
            {
              label: "A",
              name: "ace",
              id: "RANK_ACE",
            },
          ],
          suits: [
            {
              name: "club",
              color: "black",
              id: "SUIT_CLUB",
            },
            {
              name: "diamond",
              color: "red",
              id: "SUIT_DIAMOND",
            },
            {
              name: "heart",
              color: "red",
              id: "SUIT_HEART",
            },
            {
              name: "spade",
              color: "black",
              id: "SUIT_SPADE",
            },
          ],
        },
        M = (a = B).suits.map(function (e) {
          return a.ranks.map(function (t) {
            return {
              rank: t,
              suit: e,
              active: !1,
            };
          });
        }),
        D = function (e) {
          var t = {};
          for (var n in e) t[e[n]] = n;
          return t;
        },
        U = function (e) {
          return {
            rank: cardRank[e.rank.id],
            suit: cardSuit[e.suit.id],
          };
        },
        _ = function (e) {
          return B.suits.find(function (t) {
            return t.id === e;
          });
        },
        G = function (e) {
          return B.ranks.find(function (t) {
            return t.id === e;
          });
        },
        V = function (e, t) {
          return e.find(function (e) {
            return e.player === t;
          });
        },
        Q = function (e, t) {
          return e.find(function (e) {
            return e.id === t;
          }).playerName;
        },
        z = function (e) {
          return (
            e &&
            e.find(function (e) {
              return e.active;
            })
          );
        },
        Y = function (e) {
          return (
            e &&
            e.filter(function (e) {
              return e;
            })
          );
        },
        q = function (e) {
          for (var t = [], n = 0; n < (e.flop && e.flop.length); ++n)
            if (e.flop[n]) {
              var a = U(e.flop[n]);
              t.push(a.rank + a.suit);
            }
          var r = e.turn && U(e.turn),
            i = e.river && U(e.river);
          return r && t.push(r.rank + r.suit), i && t.push(i.rank + i.suit), t;
        },
        Z = function (e, t) {
          return JSON.stringify(e) === JSON.stringify(t);
        },
        X = function (e, t, n) {
          var a;
          !1 === n.type &&
            ((n.type = "player"),
            (n.id = 0),
            (n.card.type = "player"),
            (n.card.id = 0));
          var r = n.id;
          switch (n.type) {
            case "player":
              for (; r < e.length; ++r)
                if (
                  -1 !==
                  (a = e[r].hand.findIndex(function (e) {
                    return !1 === e;
                  }))
                )
                  return {
                    type: "player",
                    id: r,
                    card: {
                      type: "player",
                      id: a,
                    },
                  };
              for (r = 0; r < e.length; ++r)
                if (
                  -1 !==
                  (a = e[r].hand.findIndex(function (e) {
                    return !1 === e;
                  }))
                )
                  return {
                    type: "player",
                    id: r,
                    card: {
                      type: "player",
                      id: a,
                    },
                  };
              for (var i in t)
                if (t[i].length) {
                  if (
                    -1 !==
                    (a = t[i].findIndex(function (e) {
                      return !1 === e;
                    }))
                  )
                    return {
                      type: "table",
                      id: 0,
                      card: {
                        type: i,
                        id: a,
                      },
                    };
                } else if ((a = !1 === t[i]))
                  return {
                    type: "table",
                    id: 0,
                    card: {
                      type: i,
                      id: 0,
                    },
                  };
              break;
            case "table":
              for (var s in t)
                if (t[s].length) {
                  if (
                    -1 !==
                    (a = t[s].findIndex(function (e) {
                      return !1 === e;
                    }))
                  )
                    return {
                      type: "table",
                      id: 0,
                      card: {
                        type: s,
                        id: a,
                      },
                    };
                } else if ((a = !1 === t[s]))
                  return {
                    type: "table",
                    id: 0,
                    card: {
                      type: s,
                      id: 0,
                    },
                  };
              for (; r < e.length; ++r)
                if (
                  -1 !==
                  (a = e[r].hand.findIndex(function (e) {
                    return !1 === e;
                  }))
                )
                  return {
                    type: "player",
                    id: r,
                    card: {
                      type: "player",
                      id: a,
                    },
                  };
              for (r = 0; r < e.length; ++r)
                if (
                  -1 !==
                  (a = e[r].hand.findIndex(function (e) {
                    return !1 === e;
                  }))
                )
                  return {
                    type: "player",
                    id: r,
                    card: {
                      type: "player",
                      id: a,
                    },
                  };
              break;
            default:
              return {
                type: "player",
                id: 0,
                card: {
                  type: "player",
                  id: 0,
                },
              };
          }
          switch (n.type) {
            case "player":
              return {
                type: "player",
                id: 0,
                card: {
                  type: "player",
                  id: 0,
                },
              };
            case "table":
              return {
                type: "table",
                id: 0,
                card: {
                  type: "flop",
                  id: 0,
                },
              };
            default:
              return {
                type: "player",
                id: 0,
                card: {
                  type: "player",
                  id: 0,
                },
              };
          }
        },
        $ = function (e, t, n) {
          var a;
          switch (n.type) {
            case "player":
              for (var r = n.id; r < e.length; ++r)
                if (
                  -1 !==
                  (a = e[r].hand.findIndex(function (e) {
                    return !1 === e;
                  }))
                )
                  return {
                    type: "player",
                    id: r,
                    card: {
                      type: "player",
                      id: a,
                    },
                  };
              break;
            case "table":
              for (var i in t)
                switch (n.card.type) {
                  case "flop":
                    return -1 !==
                      (a = t[i].findIndex(function (e, t) {
                        return !(t <= n.card.id) && !1 === e;
                      }))
                      ? {
                          type: "table",
                          id: 0,
                          card: {
                            type: i,
                            id: a,
                          },
                        }
                      : (a = !1 === t.turn)
                      ? {
                          type: "table",
                          id: 0,
                          card: {
                            type: "turn",
                            id: 0,
                          },
                        }
                      : (a = !1 === t.river)
                      ? {
                          type: "table",
                          id: 0,
                          card: {
                            type: "river",
                            id: 0,
                          },
                        }
                      : X(e, t, n);
                  case "turn":
                    return (a = !1 === t.turn)
                      ? {
                          type: "table",
                          id: 0,
                          card: {
                            type: "turn",
                            id: 0,
                          },
                        }
                      : (a = !1 === t.river)
                      ? {
                          type: "table",
                          id: 0,
                          card: {
                            type: "river",
                            id: 0,
                          },
                        }
                      : X(e, t, n);
                  case "river":
                    return (a = !1 === t.river)
                      ? {
                          type: "table",
                          id: 1,
                          card: {
                            type: "river",
                            id: 0,
                          },
                        }
                      : X(e, t, n);
                  default:
                    return !1;
                }
              break;
            default:
              return !1;
          }
          return !1;
        },
        ee = function (e, t) {
          for (var n = !0, a = 0; a < e.length; ++a)
            if (
              !1 ===
              (n = e[a].hand.find(function (e) {
                return !e;
              }))
            )
              return n;
          return te(t);
        },
        te = function (e) {
          var t = !0;
          for (var n in e)
            if (e[n].length) {
              if (
                !1 ===
                (t = e[n].find(function (e) {
                  return !1 === e;
                }))
              )
                return !1;
            } else if (!(t = !!e[n])) return t;
          return !0;
        },
        ne = function (e) {
          var t = e && Y(e).length;
          return 0 === t || 3 === t;
        },
        ae = function (e, t) {
          return (
            e.hand.map(function (e) {
              return e && t++, e;
            }),
            t
          );
        },
        re = function (e) {
          for (var t = 0, n = 0, a = 0; a < e.length; ++a) {
            if (((t = ae(e[a], t)), 0 === a && (n = t), t !== n)) return !1;
            t = 0;
          }
          return !0;
        },
        ie = function (e, t, n) {
          if (e)
            for (var a = 0; a < e.length; ++a) {
              for (var r = e[a].hand, i = !1, s = 0, o = 0; s < r.length; ++s)
                if (r[s]) {
                  if (i) return !1;
                  o++;
                } else if (
                  ((i = !0), o < n.minNumberOfFilledCardsInHandForCosting)
                )
                  return !1;
              if (o < n.minNumberOfFilledCardsInHandForCosting) return !1;
            }
          var c = 0,
            l = !1;
          for (var d in t)
            if (t[d].length) {
              for (var u = 0; u < t[d].length; ++u)
                if (t[d][u]) {
                  if (l) return !1;
                  c++;
                } else if (
                  ((l = !0), c < n.minNumberOfFilledCardsOnBoardForCosting)
                )
                  return !1;
            } else if (t[d]) {
              if (l) return !1;
              c++;
            }
          return !(c < n.minNumberOfFilledCardsOnBoardForCosting);
        },
        se = n(11),
        oe = function (e, t) {
          for (var n = e.toJS(), a = 0; a < n.length; ++a) {
            var r = n[a].findIndex(function (e) {
              return Z(e, t);
            });
            if (-1 !== r) {
              n[a][r].active = !t.active;
              break;
            }
          }
          return Object(se.fromJS)(n);
        },
        ce = function (e, t) {
          var n = t.type,
            a = e.toJS().hints;
          return (
            (a.find(function (e) {
              return e.type === n;
            }).visible = !0),
            Object(se.fromJS)({
              hints: a,
            })
          );
        },
        le = n(108),
        de = n.n(le),
        ue = [
          "Players 1 and 2 are included in the hand by default.",
          "Use the second dropdown to add more players to the hand.",
          "You can also choose between Texas Hold\u2019em and Omaha in the first dropdown.",
          "On desktop select each player\u2019s hole cards, and afterwards the community cards, by clicking on the card icons on the left.",
          "On mobile select each player\u2019s hole cards, and afterwards community cards, by using the \u201cClick to choose your cards\u201d-button.",
          "Click on any cards to change them.",
          "When having chosen all cards in the hands and on the table, click the \u201cWhich Hand Wins?\u201d-button to see the result.",
          "Reset the calculator at any time by clicking the \u201cReset\u201d-button.",
        ],
        me = [
          "Players 1 and 2 are included in the hand by default.",
          "Use the second dropdown to add more players to the hand (up to 7 for Texas Hold\u2019em and Omaha and up to 5 in the Stud games).",
          "You can also choose between our different games, Texas Hold\u2019em, Texas Hold\u2019em Hi/Lo, Omaha, 7-Card Stud, 7-Card Stud Hi/Lo (with or without qualifier) and Razz.",
          "On desktop select each player\u2019s hole cards, and afterwards community cards (no community cards in the stud games), by clicking on the card icons on the left.",
          "On mobile select each player\u2019s hole cards, and afterwards community cards (no community cards in the stud games), by using the \u201cClick to choose your cards\u201d-button.",
          "Click on any cards to change them.",
          "In Hold\u2019em and Omaha you can get the chances for each player to win by clicking the \u201cCalculate Odds\u201d-button either before the flop, after the flop or after the turn.",
          "In the Stud games (including Razz) you can the chances for each player to win by clicking the \u201cCalculate Odds\u201d-button when all players have a minimum of 3 cards and the same amount exactly. You can therefore get the odds either after 3rd, 4th, 5th or 6th street.",
          "Once you have clicked the \u201cCalculate Odds\u201d-button, the odds for each player to win will be shown. You can moderate the hand afterwards and get the odds again.",
          "Reset the calculator at any time by clicking the \u201cReset\u201d-button.",
        ],
        fe = Object(se.fromJS)(M),
        pe = function (e, t) {
          for (var n = e.toJS(), a = 0; a < n.length; ++a) {
            var r = n[a].find(function (e) {
              return Z(e, t);
            });
            if (r) {
              r.active = !t.active;
              break;
            }
          }
          return Object(se.fromJS)(n);
        };
      var he = Object(se.fromJS)(J),
        ve = function (e, t) {
          var n = t.rank,
            a = t.suit,
            r = t.type;
          if (r) {
            var i = e.toJS().table;
            if (Array.isArray(i[r])) {
              var s = i[r].findIndex(function (e) {
                return Z(e, {
                  rank: n,
                  suit: a,
                });
              });
              i[r][s] = !1;
            } else i[r] = !1;
            return Object(se.fromJS)({
              table: i,
              players: e.get("players"),
              winner: !1,
              activeField: e.get("activeField"),
            });
          }
          for (var o = e.toJS().players, c = 0; c < o.length; ++c) {
            var l = o[c].hand.findIndex(function (e) {
              return Z(e, {
                rank: n,
                suit: a,
              });
            });
            if (-1 !== l) {
              o[c].hand[l] = !1;
              break;
            }
          }
          return Object(se.fromJS)({
            players: o,
            table: e.get("table"),
            winner: !1,
            activeField: e.get("activeField"),
          });
        },
        be = function (e, t) {
          var n = t.type,
            a = t.id,
            r = e.get("activeField").toJS();
          return (
            (r.card.id = a),
            (r.card.type = n || "player"),
            Object(se.fromJS)({
              table: e.get("table"),
              winner: e.get("winner"),
              activeField: Object(se.fromJS)(r),
              players: e.get("players"),
            })
          );
        },
        ge = function (e, t) {
          var n = t.winner;
          return e.set("winner", n);
        };
      var ye = Object(se.fromJS)({
          hints: [
            {
              type: "help",
              visible: !1,
            },
            {
              type: R,
              visible: !1,
            },
          ],
        }),
        ke = function (e, t) {
          var n = t.type,
            a = e.toJS().hints,
            r = a.find(function (e) {
              return e.type === n;
            });
          return (
            (r.visible = !r.visible),
            Object(se.fromJS)({
              hints: a,
            })
          );
        },
        Ce = function (e, t) {
          var n = t.type,
            a = e.toJS().hints;
          return (
            (a.find(function (e) {
              return e.type === n;
            }).visible = !1),
            Object(se.fromJS)({
              hints: a,
            })
          );
        },
        Oe = function (e, t) {
          var n = t.type,
            a = e.toJS().hints;
          return (
            (a.find(function (e) {
              return e.type === n;
            }).visible = !0),
            Object(se.fromJS)({
              hints: a,
            })
          );
        };
      var Ee = n(353),
        winnerHandFunc = function (e) {
          var t = e.board.toJS();
          if (ee(t.players, t.table)) {
            var n = e.board,
              a = n.get("players").toJS(),
              r = (function (e) {
                for (var t = [], n = 0; n < e.flop.length; ++n)
                  t.push(U(e.flop[n]));
                return (
                  t.push(U(e.turn)),
                  t.push(U(e.river)),
                  {
                    cards: t,
                  }
                );
              })(n.get("table").toJS()),
              i = gameType[z(e.settings.get("rules").toJS()).id],
              s = a.map(function (e) {
                return {
                  hand: {
                    cards: e.hand.map(function (e) {
                      return U(e);
                    }),
                  },
                  id: e.id,
                };
              }),
              o = new Ee.Game(s, r, i).getWinners().winnerResult,
              c = o[0],
              l = o
                .map(function (e) {
                  return Q(a, e.playerId);
                })
                .join(", "),
              d = o.map(function (e) {
                return e.playerId;
              }),
              m = n.toJS();
            return (
              (m.winner = {
                combination: c.handName,
                name:
                  1 === o.length
                    ? Q(a, c.playerId) + " Wins!"
                    : "Split Pot - " + l,
                cards: c.result.map(function (e) {
                  return (function (e) {
                    return {
                      rank: G(D(cardRank)[e.rank]),
                      suit: _(D(cardSuit)[e.suit]),
                    };
                  })(e);
                }),
                ids: d,
              }),
              (m.carousel = {
                hasChanged: !0,
              }),
              Object(u.a)({}, e, {
                board: Object(se.fromJS)(m),
              })
            );
          }
          return Object(u.a)({}, e, {
            hints: ce(e.hints, {
              type: R,
            }),
          });
        },
        Se = Object(m.a)(
          Object(l.c)({
            menu: function () {
              var e =
                  arguments.length > 0 && void 0 !== arguments[0]
                    ? arguments[0]
                    : fe,
                t = arguments.length > 1 ? arguments[1] : void 0;
              switch (t.type) {
                case toggCard:
                  return pe(e, t.payload);
                default:
                  return e;
              }
            },
            board: function () {
              var e =
                  arguments.length > 0 && void 0 !== arguments[0]
                    ? arguments[0]
                    : he,
                t = arguments.length > 1 ? arguments[1] : void 0;
              switch (t.type) {
                case removCard:
                  return ve(e, t.payload);
                case y:
                  return be(e, t.payload);
                case setWinner:
                  return ge(e, t.payload);
                default:
                  return e;
              }
            },
            hints: function () {
              var e =
                  arguments.length > 0 && void 0 !== arguments[0]
                    ? arguments[0]
                    : ye,
                t = arguments.length > 1 ? arguments[1] : void 0;
              switch (t.type) {
                case v:
                  return ke(e, t.payload);
                case b:
                  return Ce(e, t.payload);
                case g:
                  return Oe(e, t.payload);
                default:
                  return e;
              }
            },
            settings: function () {
              return arguments.length > 0 && void 0 !== arguments[0]
                ? arguments[0]
                : Object(se.fromJS)(W);
            },
          }),
          function (e, t) {
            switch (t.type) {
              case "ADD_CARD_TO_BOARD":
                return (function (e, t) {
                  var n,
                    a = t.rank,
                    r = t.suit,
                    i = t.active,
                    s = e.board.toJS(),
                    o = s.players,
                    c = s.table,
                    l = s.activeField,
                    d = l.card.id,
                    u = l.id;
                  if (l)
                    if ("player" === l.type) {
                      if (o[u]) {
                        var m = o[u].hand;
                        m[d] ||
                          ((m[d] = {
                            rank: a,
                            suit: r,
                          }),
                          (n = oe(e.menu, {
                            rank: a,
                            suit: r,
                            active: i,
                          })));
                      }
                    } else if ("table" === l.type && Object.keys(c).length)
                      switch (l.card.type) {
                        case "flop":
                          c[l.card.type][l.card.id] ||
                            ((c[l.card.type][l.card.id] = {
                              rank: a,
                              suit: r,
                            }),
                            (n = oe(e.menu, {
                              rank: a,
                              suit: r,
                              active: i,
                            })));
                          break;
                        case "turn":
                        case "river":
                          c[l.card.type] ||
                            ((c[l.card.type] = {
                              rank: a,
                              suit: r,
                            }),
                            (n = oe(e.menu, {
                              rank: a,
                              suit: r,
                              active: i,
                            })));
                      }
                  return {
                    hints: e.hints,
                    menu: n || e.menu,
                    board: Object(se.fromJS)({
                      table: c,
                      players: o,
                      activeField: l,
                      winner: e.board.get("winner"),
                    }),
                    settings: e.settings,
                  };
                })(e, t.payload);
              case "UPDATE_ACTIVE_FIELD":
                return (function (e) {
                  var t,
                    n = e.board.toJS(),
                    a = n.players,
                    r = n.table,
                    i = n.activeField,
                    s = i.id;
                  if (i)
                    if ("player" === i.type)
                      a[s] &&
                        (t = X(a, r, i)) &&
                        ((i.type = t.type),
                        (i.id = t.id),
                        (i.card.id = t.card.id),
                        (i.card.type = t.card.type));
                    else if ("table" === i.type && Object.keys(r).length)
                      switch (i.card.type) {
                        case "flop":
                        case "turn":
                        case "river":
                          (t = $(a, r, i)) &&
                            ((i.type = t.type),
                            (i.id = t.id),
                            (i.card.id = t.card.id),
                            (i.card.type = t.card.type));
                      }
                  return (
                    ee(a, r) &&
                      ((i.type = !1),
                      (i.id = !1),
                      (i.card.id = !1),
                      (i.card.type = !1)),
                    {
                      hints: e.hints,
                      menu: e.menu,
                      board: Object(se.fromJS)({
                        table: r,
                        players: a,
                        activeField: i,
                        winner: e.board.get("winner"),
                      }),
                      settings: e.settings,
                    }
                  );
                })(e);
              case C:
                return (function (e, t) {
                  return Object(u.a)({}, e, {
                    board: e.board.set("players", Object(se.fromJS)(t.players)),
                  });
                })(e, t.payload);
              case O:
                return (function (e, t) {
                  return Object(u.a)({}, e, {
                    board: e.board.set("carousel", Object(se.fromJS)(t)),
                  });
                })(e, t.payload);
              case "GET_WINNER_HAND":
                return winnerHandFunc(e);
              case "SET_RULES":
                return (function (e, t) {
                  var n = t.id,
                    a = e.settings,
                    r = e.board.toJS(),
                    i = "poc" === a.get("id"),
                    s = a
                      .get("rules")
                      .toJS()
                      .map(function (e) {
                        return Object(u.a)({}, e, {
                          active: !1,
                        });
                      }),
                    o = z(a.get("players").toJS()).id,
                    c = s.find(function (e) {
                      return e.id === n;
                    });
                  c.active = !0;
                  var l = I(c.rules.minPlayers, c.rules.maxPlayers, o),
                    d = T([], z(l).id, z(s).rules.numberOfCardsInHand);
                  return (
                    (r.players = Object(se.fromJS)(d)),
                    (r.table = Object(se.fromJS)(
                      x(c.rules.numberOfCardsOnBoard)
                    )),
                    (r.activeField = i
                      ? {
                          type: "player",
                          id: 0,
                          card: {
                            type: "player",
                            id: 0,
                          },
                        }
                      : X(d, L, r.activeField)),
                    (r.winner = !1),
                    Object(u.a)({}, e, {
                      board: Object(se.fromJS)(r),
                      settings: Object(se.fromJS)({
                        id: a.get("id"),
                        rules: Object(se.fromJS)(s),
                        players: Object(se.fromJS)(l),
                      }),
                    })
                  );
                })(e, t.payload);
              case "SET_PLAYERS_COUNT":
                return (function (e, t) {
                  var n = t.id,
                    a = e.settings,
                    r = e.menu.toJS(),
                    i = e.board.toJS(),
                    s = a
                      .get("players")
                      .toJS()
                      .map(function (e) {
                        return Object(u.a)({}, e, {
                          active: !1,
                        });
                      }),
                    o = e.board.get("players").toJS(),
                    c = n - o.length;
                  if (c <= 0)
                    for (var l = 0; l < Math.abs(c); ++l)
                      o[o.length - l - 1].hand.map(function (e) {
                        for (var t = 0; t < r.length; ++t) {
                          var n = r[t].findIndex(function (t) {
                            return Z(
                              Object(u.a)({}, e, {
                                active: !0,
                              }),
                              t
                            );
                          });
                          if (-1 !== n) {
                            r[t][n].active = !1;
                            break;
                          }
                        }
                        return Object(u.a)({}, e);
                      });
                  var d = T(
                    o,
                    c,
                    z(a.get("rules").toJS()).rules.numberOfCardsInHand
                  );
                  return (
                    (s.find(function (e) {
                      return e.id === n;
                    }).active = !0),
                    (i.activeField = X(d, i.table, i.activeField)),
                    (i.players = Object(se.fromJS)(d)),
                    (i.winner = !1),
                    Object(u.a)({}, e, {
                      menu: Object(se.fromJS)(r),
                      board: Object(se.fromJS)(i),
                      settings: a.set("players", Object(se.fromJS)(s)),
                    })
                  );
                })(e, t.payload);
              case "SET_ACTIVE_FIELD":
                return (function (e, t) {
                  var n = t.type,
                    a = t.id,
                    r = t.isCardClicked,
                    i = e.board.get("activeField").toJS();
                  return (
                    (i.id = --a),
                    (i.type = n),
                    r ||
                      ((i.card.id = 0),
                      (i.card.type = "table" === n ? "flop" : "player")),
                    Object(u.a)({}, e, {
                      board: e.board.set("activeField", Object(se.fromJS)(i)),
                    })
                  );
                })(e, t.payload);
              case "RESET":
                return (function (e) {
                  var t = e.settings.toJS(),
                    n = z(t.rules).rules,
                    a = H(
                      z(t.players).id,
                      n.numberOfCardsInHand,
                      x(n.numberOfCardsOnBoard)
                    );
                  return (
                    (a.carousel = {
                      hasChanged: !0,
                      reset: !0,
                    }),
                    Object(u.a)({}, e, {
                      menu: fe,
                      board: Object(se.fromJS)(a),
                    })
                  );
                })(e);
              default:
                return e;
            }
          }
        ),
        we = n(81),
        Ae = n.n(we),
        Re = n(65),
        Fe = function (e) {
          return e.board;
        },
        Te = function (e) {
          return e.settings;
        },
        Ie = n(354),
        He = n.n(Ie),
        je = function (e, t) {
          for (var n = 0; n < e.length; ++n) {
            var a = V(t, e[n].id).results;
            (e[n].win = parseInt(a.win) + "%"),
              a.winLo
                ? (e[n].winLo = parseInt(a.winLo) + "%")
                : (e[n].tie = parseInt(a.tie) + "%");
          }
          return e;
        },
        xe = Ae.a.mark(Ke),
        Pe = Ae.a.mark(We),
        Le = Ae.a.mark(Be),
        Je = Ae.a.mark(Me);

      function Ke(e) {
        var t, n, a, r, i, s, o, c, l, d, m, f;
        return Ae.a.wrap(function (p) {
          for (;;)
            switch ((p.prev = p.next)) {
              case 0:
                return (t = e.payload.callback), (p.next = 3), Object(Re.d)(Fe);
              case 3:
                return (
                  (n = p.sent),
                  (a = n.get("players").toJS()),
                  (r = n.get("table").toJS()),
                  (p.next = 8),
                  Object(Re.d)(Te)
                );
              case 8:
                if (
                  ((i = p.sent),
                  (s = z(i.get("rules").toJS())),
                  !ie(a, r, s.rules))
                ) {
                  p.next = 39;
                  break;
                }
                if (
                  ((o = w[s.id]),
                  (c = q(r).join(",")),
                  (l = {}),
                  (d = 0),
                  (s.rules.noCommunityCards || ne(r.flop)) &&
                    (!s.rules.noCommunityCards || re(a)))
                ) {
                  p.next = 20;
                  break;
                }
                return (p.next = 19), Object(Re.b)(We);
              case 19:
                return p.abrupt("return", p.sent);
              case 20:
                for (; d < a.length; ++d)
                  l["player_" + (d + 1)] = a[d].hand
                    .filter(function (e) {
                      return e;
                    })
                    .map(function (e) {
                      var t = U(e);
                      return t.rank + t.suit;
                    })
                    .join(",");
                return (
                  (m = Object(u.a)({}, l)),
                  c && (m.board_cards = c),
                  (p.next = 25),
                  Object(Re.b)(function () {
                    return He.a.get(
                      "https://www.pokerlistings.com/wp-json/pokerlistings/v1/poker/?game=".concat(
                        o,
                        "&action=odds"
                      ),
                      {
                        params: Object(u.a)({}, m),
                      }
                    );
                  })
                );
              case 25:
                if (200 !== (f = p.sent).status) {
                  p.next = 34;
                  break;
                }
                return (
                  (p.next = 29),
                  Object(Re.c)({
                    type: C,
                    payload: {
                      players: je(a, f.data.results.players),
                    },
                  })
                );
              case 29:
                return (
                  (p.next = 31),
                  Object(Re.c)({
                    type: O,
                    payload: {
                      hasChanged: !0,
                    },
                  })
                );
              case 31:
                t && t(!0), (p.next = 37);
                break;
              case 34:
                return (p.next = 36), Object(Re.b)(We);
              case 36:
                return p.abrupt("return", p.sent);
              case 37:
                p.next = 42;
                break;
              case 39:
                return (p.next = 41), Object(Re.b)(We);
              case 41:
                return p.abrupt("return", p.sent);
              case 42:
              case "end":
                return p.stop();
            }
        }, xe);
      }

      function We() {
        return Ae.a.wrap(function (e) {
          for (;;)
            switch ((e.prev = e.next)) {
              case 0:
                return (
                  (e.next = 2),
                  Object(Re.c)({
                    type: g,
                    payload: {
                      type: R,
                    },
                  })
                );
              case 2:
                return e.abrupt("return", e.sent);
              case 3:
              case "end":
                return e.stop();
            }
        }, Pe);
      }

      function Be() {
        return Ae.a.wrap(function (e) {
          for (;;)
            switch ((e.prev = e.next)) {
              case 0:
                return (e.next = 2), Object(Re.e)(calcOdds, Ke);
              case 2:
              case "end":
                return e.stop();
            }
        }, Le);
      }

      function Me() {
        return Ae.a.wrap(function (e) {
          for (;;)
            switch ((e.prev = e.next)) {
              case 0:
                return (e.next = 2), Object(Re.a)([Be()]);
              case 2:
              case "end":
                return e.stop();
            }
        }, Je);
      }
      var De = Object(d.a)(),
        Ue = Object(l.a)(De),
        _e =
          window.__REDUX_DEVTOOLS_EXTENSION__ &&
          window.__REDUX_DEVTOOLS_EXTENSION__(),
        Ge = Object(l.e)(Se, _e ? Object(l.d)(Ue, _e) : Object(l.d)(Ue));
      De.run(Me);
      var Ve = Ge,
        Qe = (n(626), n(40)),
        ze =
          (n(627),
          n(304),
          n(676),
          n(863),
          function (e, t, n) {
            return {
              type: removCard,
              payload: {
                rank: e,
                suit: t,
                type: n,
              },
            };
          }),
        Ye = function (e, t, n) {
          return {
            type: toggCard,
            payload: {
              rank: e,
              suit: t,
              active: n,
            },
          };
        },
        qe = function (e) {
          return {
            type: b,
            payload: {
              type: e,
            },
          };
        },
        Ze = function (e) {
          return {
            type: calcOdds,
            payload: {
              callback: e,
            },
          };
        },
        Xe = function (e, t) {
          return {
            type: y,
            payload: {
              type: e,
              id: t,
            },
          };
        },
        $e = n(28),
        et = n(123),
        tt = (n(865), n(866), n(867), n(356).stringify),
        nt = function (e) {
          var t = e.rank,
            n = e.suit,
            a = e.active,
            r = e.addCardToBoard,
            s = e.updateActiveField,
            o = e.updateActiveFieldDelay,
            c = e.player,
            l = e.removeCard,
            d = e.type,
            u = e.result,
            m = e.board,
            f = e.setChosenCard,
            p = e.handId,
            h = e.chosen,
            v = e.menu,
            b = e.menuState,
            g = e.setCardsMenu,
            y = e.disable,
            k = e.setDisableCards,
            C = e.isResult;
          return n && t
            ? i.a.createElement(
                "div",
                {
                  className: tt({
                    block: "card",
                    mods: {
                      active: !!a,
                      player: !!c,
                      board: !!m,
                      result: !!u,
                      chosen: !!h,
                      menu: !!v,
                      "menu-state": !!b,
                      "is-result": !!C,
                      disable: !!y,
                    },
                  }),
                  onClick: function () {
                    !a &&
                      v &&
                      (r(t, n, a, g),
                      o
                        ? (k(!0),
                          setTimeout(function () {
                            s(), k(!1);
                          }, 500))
                        : s()),
                      (c || m || b) && !y && (l(t, n, d), f(d, p)),
                      m && !y && s();
                  },
                },
                i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: "card",
                      elem: "wrapper",
                    }),
                  },
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: "card",
                        elem: "rank-wrapper",
                      }),
                    },
                    i.a.createElement("div", {
                      className: tt({
                        block: "card",
                        elem: "rank-item",
                        mods: (function () {
                          var e;
                          return (
                            (e = {}),
                            Object($e.a)(e, t.name, !0),
                            Object($e.a)(e, n.color, !0),
                            e
                          );
                        })(),
                      }),
                    })
                  ),
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: "card",
                        elem: "suit-wrapper",
                      }),
                    },
                    i.a.createElement("div", {
                      className: tt({
                        block: "card",
                        elem: "suit-item",
                        mods: Object($e.a)({}, n.name, !0),
                      }),
                    })
                  )
                )
              )
            : i.a.createElement("div", {
                className: tt({
                  block: "card",
                  mods: {
                    shirt: !0,
                    board: !!m,
                    chosen: !!h,
                    "menu-state": !!b,
                    disable: !!y,
                  },
                }),
                onClick: function () {
                  y || (f(d, p), m && s());
                },
              });
        },
        at = function (e, t) {
          return t ? t.rank.name.toString() + t.suit.name.toString() + e : e;
        },
        rt = function (e) {
          var t = e.cards,
            n = e.addCardToBoard,
            a = e.updateActiveField,
            s = e.updateActiveFieldDelay,
            o = e.setCardsMenu,
            c = e.isMobile,
            l = Object(r.useState)(!1),
            d = Object(Qe.a)(l, 2),
            u = d[0],
            m = d[1];
          return i.a.createElement(
            "div",
            {
              className: "container__card",
            },
            t.map(function (e, t) {
              return c
                ? i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: "container__card",
                        elem: "item",
                      }),
                      key: at(t, e),
                    },
                    i.a.createElement(nt, {
                      key: at(t, e),
                      rank: e.rank,
                      suit: e.suit,
                      active: e.active,
                      addCardToBoard: n,
                      updateActiveField: a,
                      updateActiveFieldDelay: s,
                      setCardsMenu: o,
                      disable: u,
                      setDisableCards: m,
                      menu: !0,
                    })
                  )
                : i.a.createElement(nt, {
                    key: at(t, e),
                    rank: e.rank,
                    suit: e.suit,
                    active: e.active,
                    addCardToBoard: n,
                    updateActiveField: a,
                    setCardsMenu: o,
                    menu: !0,
                  });
            })
          );
        },
        it =
          (n(869),
          function (e, t) {
            Object(r.useEffect)(
              function () {
                return (
                  t.current && document.addEventListener("click", n),
                  function () {
                    return document.removeEventListener("click", n);
                  }
                );

                function n(n) {
                  t.current && !t.current.contains(n.target) && e && e(n);
                }
              },
              [e, t]
            );
          }),
        st = function (e) {
          var t = Object(r.useRef)();
          return (
            Object(r.useEffect)(function () {
              t.current = e;
            }),
            t.current
          );
        },
        ot = function (e) {
          var t = e.options,
            n = e.game,
            a = e.players,
            s = e.setOption,
            o = Object(r.useState)(!1),
            c = Object(Qe.a)(o, 2),
            l = c[0],
            d = c[1],
            u = Object(r.useRef)(null);
          it(function () {
            return d(!1);
          }, u);
          return i.a.createElement(
            "div",
            {
              className: tt({
                block: "choose-dropdown",
                mods: {
                  players: !!a,
                  game: !!n,
                  open: l,
                },
              }),
              ref: u,
              onClick: function () {
                return d(!l);
              },
            },
            i.a.createElement(
              "div",
              {
                className: tt({
                  block: "choose-dropdown",
                  elem: "active",
                }),
              },
              (function () {
                var e = z(t);
                return !!e && e.name;
              })()
            ),
            l &&
              i.a.createElement(
                "div",
                {
                  className: tt({
                    block: "choose-dropdown",
                    elem: "items",
                  }),
                },
                t.map(function (e) {
                  var t = e.id;
                  return (
                    !e.active &&
                    i.a.createElement(
                      "div",
                      {
                        key: t,
                        className: tt({
                          block: "choose-dropdown",
                          elem: "option",
                        }),
                        onClick: function () {
                          return s(t);
                        },
                      },
                      e.name
                    )
                  );
                })
              )
          );
        },
        ct =
          (n(870),
          function (e) {
            var t = e.title,
              n = e.info,
              a = e.close,
              r = e.type,
              s = e.hints,
              o = e.list,
              c = function () {
                return Object($e.a)({}, r, !!r);
              },
              l = function () {
                return a(r);
              };
            return i.a.createElement(
              "div",
              {
                className: tt({
                  block: "hint",
                  elem: "wrapper",
                  mods: Object(u.a)(
                    {},
                    {
                      visible: !!s.find(function (e) {
                        return e.type === r;
                      }).visible,
                    },
                    c()
                  ),
                }),
              },
              i.a.createElement("div", {
                className: tt({
                  block: "hint",
                  elem: "dark",
                  mods: c(),
                }),
                onClick: l,
              }),
              i.a.createElement(
                "div",
                {
                  className: tt({
                    block: "hint",
                    mods: c(),
                  }),
                },
                i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: "hint",
                      elem: "title",
                      mods: c(),
                    }),
                  },
                  t
                ),
                i.a.createElement(
                  "ul",
                  {
                    className: tt({
                      block: "hint",
                      elem: "list",
                    }),
                  },
                  o &&
                    o.map(function (e, t) {
                      return i.a.createElement(
                        "li",
                        {
                          key: e + t,
                        },
                        e
                      );
                    })
                ),
                i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: "hint",
                      elem: "info",
                      mods: c(),
                    }),
                  },
                  n
                ),
                i.a.createElement("div", {
                  className: tt({
                    block: "hint",
                    elem: "close",
                  }),
                  onClick: l,
                })
              )
            );
          }),
        lt =
          (n(871),
          function (e) {
            var t = e.click,
              n = e.children,
              a = e.type;
            return i.a.createElement(
              "button",
              {
                className: tt({
                  block: "button",
                  mods: Object($e.a)({}, a, !0),
                }),
                onClick: t,
              },
              n
            );
          }),
        dt = function (e) {
          var t = e.menu,
            n = e.addCardToBoard,
            a = e.updateActiveField,
            s = e.hints,
            o = e.toggleHint,
            c = e.closeHint,
            l = e.showHint,
            d = e.reset,
            u = e.calculateOdds,
            m = e.getWinnerHand,
            f = e.settingsRules,
            p = e.settingsPlayers,
            h = e.setPlayersCount,
            v = e.setRules,
            b = e.activeFieldType,
            g = e.activeFieldId,
            y = e.activeFieldCardId,
            k = e.activeFieldCardType,
            C = e.players,
            O = e.table,
            E = e.setChosenCard,
            N = e.removeCard,
            S = e.isPOC,
            w = e.currentFieldInfo,
            A = e.setCardsMenu,
            F = e.cardsMenu,
            T = e.everythingChosen,
            I = e.cardsLeftToPick,
            H = e.errorInfo,
            j = e.isMobile,
            x = e.noCommunityCards,
            P = "menu",
            L = Object(r.useRef)(null),
            J = st(T),
            K = function (e) {
              v(e), d();
            },
            W = function () {
              var e = L.current && L.current.offsetHeight;
              U(e);
            };
          Object(r.useEffect)(function () {
            T &&
              T !== J &&
              setTimeout(function () {
                return A(!1);
              }, 500);
          });
          var B = Object(r.useState)(null),
            M = Object(Qe.a)(B, 2),
            D = M[0],
            U = M[1],
            _ = {
              top: D + "px",
              height: "calc(100% - ".concat(D + "px", ")"),
            };
          Object(r.useEffect)(function () {
            return (
              window.addEventListener("resize", W),
              function () {
                return window.removeEventListener("resize", W);
              }
            );
          }, []),
            Object(r.useEffect)(function () {
              W();
            });
          return i.a.createElement(
            "div",
            {
              className: P,
            },
            i.a.createElement(et.a, {
              query: "(min-width: 835px)",
              render: function () {
                return i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: P,
                      elem: "header",
                    }),
                  },
                  i.a.createElement("div", {
                    className: tt({
                      block: P,
                      elem: "logo",
                    }),
                  }),
                  S ? "POKER ODDS CALCULATOR" : "WINNING HANDS TOOL"
                );
              },
            }),
            i.a.createElement(
              "div",
              {
                className: tt({
                  block: P,
                  elem: "choose-wrapper",
                }),
              },
              i.a.createElement(
                "div",
                {
                  className: tt({
                    block: P,
                    elem: "choose-block",
                  }),
                },
                i.a.createElement(
                  et.a,
                  {
                    query: "(max-width: 834px)",
                  },
                  function (e) {
                    return e
                      ? i.a.createElement(
                          "div",
                          {
                            className: tt({
                              block: P,
                              elem: "choose-items",
                            }),
                          },
                          i.a.createElement(ot, {
                            options: f,
                            setOption: K,
                            game: !0,
                          }),
                          i.a.createElement(ot, {
                            options: p,
                            setOption: h,
                            players: !0,
                          })
                        )
                      : i.a.createElement(
                          i.a.Fragment,
                          null,
                          i.a.createElement(
                            "div",
                            {
                              className: tt({
                                block: P,
                                elem: "choose-title",
                              }),
                            },
                            "Choose the game"
                          ),
                          i.a.createElement(
                            "div",
                            {
                              className: tt({
                                block: P,
                                elem: "choose-subtitle",
                              }),
                            },
                            "and number of players"
                          )
                        );
                  }
                )
              ),
              i.a.createElement("div", {
                className: tt({
                  block: P,
                  elem: "choose-hint-button",
                }),
                onClick: function () {
                  return o("help");
                },
              })
            ),
            i.a.createElement(
              et.a,
              {
                query: "(max-width: 834px)",
              },
              function (e) {
                return e
                  ? i.a.createElement(
                      "div",
                      {
                        className: tt({
                          block: P,
                          elem: "choose-items-block",
                        }),
                      },
                      i.a.createElement(
                        "div",
                        {
                          className: tt({
                            block: P,
                            elem: "choose-button",
                          }),
                          onClick: function () {
                            return A(!0);
                          },
                        },
                        "Click to choose your cards"
                      )
                    )
                  : i.a.createElement(
                      "div",
                      {
                        className: tt({
                          block: P,
                          elem: "choose-items",
                        }),
                      },
                      i.a.createElement(ot, {
                        options: f,
                        setOption: K,
                        game: !0,
                      }),
                      i.a.createElement(ot, {
                        options: p,
                        setOption: h,
                        players: !0,
                      })
                    );
              }
            ),
            i.a.createElement(
              "div",
              {
                className: tt({
                  block: P,
                  elem: "help-hint",
                }),
              },
              i.a.createElement(ct, {
                title: S
                  ? "How to use the Poker Odds Calculator"
                  : "How to use our Which Hand Wins Calculator",
                info:
                  !S &&
                  "Once you have clicked the \u201cWhich Hand Wins\u201d-button, the best hand will be highlighted and an explanation visually and in text will appear. If two or more players have the same five-card hand in terms of strength, it\u2019s a split pot and more players will be highlighted.",
                list: S ? me : ue,
                hints: s,
                type: "help",
                show: l,
                close: c,
              })
            ),
            i.a.createElement(
              "div",
              {
                className: tt({
                  block: P,
                  elem: "cards",
                  mods: {
                    visible: !!F,
                  },
                }),
              },
              i.a.createElement(
                "div",
                {
                  className: tt({
                    block: P,
                    elem: "cards-wrapper",
                  }),
                },
                j &&
                  i.a.createElement(
                    "div",
                    {
                      ref: L,
                      className: tt({
                        block: P,
                        elem: "choose-top-block",
                      }),
                    },
                    i.a.createElement(
                      "div",
                      {
                        className: tt({
                          block: P,
                          elem: "choose-cards",
                        }),
                      },
                      i.a.createElement(
                        "div",
                        null,
                        i.a.createElement(
                          "div",
                          {
                            className: tt({
                              block: P,
                              elem: "choose-cards-title",
                            }),
                          },
                          "Choose your cards"
                        ),
                        i.a.createElement(
                          "div",
                          {
                            className: tt({
                              block: P,
                              elem: "choose-cards-subtitle",
                            }),
                          },
                          w,
                          "player" === b &&
                            i.a.createElement(
                              i.a.Fragment,
                              null,
                              x && "Choose minimum 3 cards, and up to 6",
                              !x &&
                                i.a.createElement(
                                  i.a.Fragment,
                                  null,
                                  i.a.createElement(
                                    "span",
                                    null,
                                    I,
                                    " more ",
                                    1 === I ? "card" : "cards"
                                  ),
                                  " to pick "
                                )
                            )
                        )
                      ),
                      i.a.createElement(lt, {
                        click: function () {
                          return A(!1);
                        },
                        type: "close",
                      })
                    ),
                    i.a.createElement(
                      i.a.Fragment,
                      null,
                      ("player" === b || !de()(O)) &&
                        i.a.createElement(
                          "div",
                          {
                            className: tt({
                              block: P,
                              elem: "player-cards",
                              mods: Object($e.a)(
                                {},
                                "count-" + C[0].hand.length,
                                !!C
                              ),
                            }),
                          },
                          (function () {
                            var e = C.find(function (e, t) {
                              return (
                                (b && t === g) ||
                                ("player" !== b &&
                                  !de()(O) &&
                                  e.id === C.length)
                              );
                            });
                            return (
                              e &&
                              e.hand.map(function (t, n) {
                                return i.a.createElement(nt, {
                                  rank: t && t.rank,
                                  suit: t && t.suit,
                                  key: at(n, t),
                                  playerId: e.id,
                                  handId: n,
                                  chosen: y === n,
                                  menuState: !0,
                                  removeCard: N,
                                  setChosenCard: E,
                                });
                              })
                            );
                          })()
                        ),
                      (("table" === b && O) || (!b && de()(O) > 0)) &&
                        i.a.createElement(
                          "div",
                          {
                            className: tt({
                              block: P,
                              elem: "table-cards",
                              mods: Object($e.a)(
                                {},
                                "count-" +
                                  (function (e) {
                                    for (
                                      var t = 0, n = 0;
                                      n < (e.flop && e.flop.length);
                                      ++n
                                    )
                                      void 0 !== e.flop[n] && t++;
                                    return (
                                      void 0 !== e.turn && t++,
                                      void 0 !== e.river && t++,
                                      t
                                    );
                                  })(O),
                                !!O
                              ),
                            }),
                          },
                          O.flop &&
                            O.flop.map(function (e, t) {
                              return i.a.createElement(nt, {
                                key: e + t,
                                handId: t,
                                rank: e.rank,
                                suit: e.suit,
                                chosen: "flop" === k && y === t,
                                type: "flop",
                                removeCard: N,
                                setChosenCard: E,
                                menuState: !0,
                              });
                            }),
                          void 0 !== O.turn &&
                            i.a.createElement(nt, {
                              rank: O.turn.rank,
                              suit: O.turn.suit,
                              chosen: "turn" === k,
                              type: "turn",
                              menuState: !0,
                              removeCard: N,
                              setChosenCard: E,
                            }),
                          void 0 !== O.river &&
                            i.a.createElement(nt, {
                              rank: O.river.rank,
                              suit: O.river.suit,
                              type: "river",
                              chosen: "river" === k,
                              menuState: !0,
                              removeCard: N,
                              setChosenCard: E,
                            })
                        )
                    )
                  ),
                i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: P,
                      elem: "choose-main-block",
                    }),
                    style: _,
                  },
                  t.map(function (e, t) {
                    return i.a.createElement(rt, {
                      key: t,
                      cards: e,
                      addCardToBoard: n,
                      updateActiveField: a,
                      updateActiveFieldDelay: j && 1 === I,
                      setCardsMenu: A,
                      isMobile: j,
                    });
                  }),
                  j &&
                    i.a.createElement(
                      lt,
                      {
                        click: d,
                        type: "grey",
                      },
                      "Reset"
                    )
                )
              )
            ),
            !j &&
              i.a.createElement(
                "div",
                {
                  className: tt({
                    block: P,
                    elem: "buttons-wrapper",
                  }),
                },
                i.a.createElement(
                  lt,
                  {
                    click: S ? u : m,
                    type: "blue",
                  },
                  S ? "Calculate Odds" : "Which Hand Wins?"
                ),
                i.a.createElement(
                  lt,
                  {
                    click: d,
                    type: "grey",
                  },
                  "Reset"
                )
              ),
            i.a.createElement(
              "div",
              {
                className: tt({
                  block: P,
                  elem: "error-popup",
                }),
              },
              i.a.createElement(ct, {
                title: "Error",
                info: H,
                hints: s,
                type: R,
                close: c,
              })
            )
          );
        },
        ut = Object(c.b)(
          function (e) {
            return (function (e) {
              var t = e.menu.toJS(),
                n = e.settings.toJS(),
                a = e.board.toJS(),
                r = e.hints.toJS(),
                i = a.players,
                s = a.table,
                o = a.activeField,
                c = o.type,
                l = o.id,
                d = o && o.card.id,
                u = o && o.card.type,
                m = "poc" === n.id,
                f = ee(i, s),
                p = n.rules,
                h = z(p).rules,
                v = h.noCommunityCards,
                b = n.players;
              return {
                hints: r.hints,
                cardsLeftToPick: (function () {
                  var e = 0;
                  if ("player" === c) {
                    var t = i[o.id].hand,
                      n = Y(t);
                    e = t.length - n.length;
                  } else
                    for (var a in s) {
                      var r = s[a],
                        l = r.length;
                      l && (e += l - Y(r).length), r || e++;
                    }
                  return e;
                })(),
                currentFieldInfo:
                  "player" !== c && de()(s)
                    ? m
                      ? "Choose 0, 3 or 4 community cards"
                      : "Choose 5 table cards"
                    : "player" === c || de()(s)
                    ? "".concat("Player", " ").concat(o.id + 1, ": ")
                    : "".concat("Player", " ").concat(i.length, ": "),
                errorInfo: (function () {
                  if (m) {
                    if (v) {
                      if (!ie(i, s, h))
                        return "Please select minimum 3 cards per player";
                      if (!re(i))
                        return "Please select the same amount of cards per player";
                    }
                    return ne(s.flop)
                      ? "Please select all hole cards"
                      : "Please select a full flop";
                  }
                  return "Please select all cards";
                })(),
                menu: t,
                settingsPlayers: b,
                settingsRules: p,
                players: i,
                table: s,
                isPOC: m,
                activeFieldType: c,
                activeFieldId: l,
                activeFieldCardId: d,
                activeFieldCardType: u,
                everythingChosen: f,
                noCommunityCards: v,
              };
            })(e);
          },
          function (e) {
            return {
              addCardToBoard: function (t, n, a) {
                e(
                  (function (e, t, n) {
                    return {
                      type: "ADD_CARD_TO_BOARD",
                      payload: {
                        rank: e,
                        suit: t,
                        active: n,
                      },
                    };
                  })(t, n, a)
                );
              },
              updateActiveField: function () {
                e({
                  type: "UPDATE_ACTIVE_FIELD",
                });
              },
              closeHint: function (t) {
                e(qe(t));
              },
              showHint: function (t) {
                e(
                  (function (e) {
                    return {
                      type: g,
                      payload: {
                        type: e,
                      },
                    };
                  })(t)
                );
              },
              toggleHint: function (t) {
                e(
                  (function (e) {
                    return {
                      type: v,
                      payload: {
                        type: e,
                      },
                    };
                  })(t)
                );
              },
              reset: function () {
                e({
                  type: "RESET",
                });
              },
              calculateOdds: function () {
                e(Ze());
              },
              getWinnerHand: function () {
                e({
                  type: "GET_WINNER_HAND",
                });
              },
              setPlayersCount: function (t) {
                e(
                  (function (e) {
                    return {
                      type: "SET_PLAYERS_COUNT",
                      payload: {
                        id: e,
                      },
                    };
                  })(t)
                );
              },
              setRules: function (t) {
                e(
                  (function (e) {
                    return {
                      type: "SET_RULES",
                      payload: {
                        id: e,
                      },
                    };
                  })(t)
                );
              },
              setChosenCard: function (t, n) {
                e(Xe(t, n));
              },
              removeCard: function (t, n, a) {
                e(ze(t, n, a)), e(Ye(t, n, !0));
              },
            };
          }
        )(dt),
        mt = (n(872), n(357)),
        ft = n.n(mt),
        pt = (n(876), n(236)),
        ht =
          (n(877),
          n(878),
          function (e) {
            var t = e.active,
              n = e.children,
              a = e.percent;
            return i.a.createElement(
              pt.a,
              {
                strokeWidth: 10,
                value: a || 0 === a ? a : t ? 100 : 0,
                styles: Object(pt.b)({
                  rotation: 0.5,
                  pathTransitionDuration: 0.5,
                  pathColor:
                    a || 0 === a
                      ? a > 50
                        ? "#1dde77"
                        : a > 25
                        ? "#f2f56e"
                        : "#d71e00"
                      : !!t && "#0087C1",
                  trailColor: "#2F2F2F",
                }),
              },
              n
            );
          }),
        vt = /card\b/,
        bt = function (e) {
          var t = e.player,
            n = e.removeCard,
            a = e.activeField,
            r = e.setActiveField,
            s = e.setChosenCard,
            o = e.isNotWinnerPlayer,
            c = e.isPOC,
            l = e.isWinnerCard,
            d = e.isResult,
            u = e.setCardsMenu,
            m = e.slider,
            f = e.splitPotWinner,
            p = e.noCommunityCards,
            h = e.hiLo,
            v = (e.oddsWinner, "player"),
            b = !!a && !o,
            g = a && "player" === a.type,
            y = function (e) {
              return g && (a && a.card.id) === e;
            },
            k = function (e, t) {
              return f || l(t) || (g && (a && a.card.id) === e);
            },
            C = function () {
              if (c) {
                var e = parseFloat(t.win);
                return h ? (e + parseFloat(t.winLo)) / 2 : e || 0;
              }
              return !1;
            };
          return d
            ? i.a.createElement(
                "div",
                {
                  className: tt({
                    block: v,
                    mods: {
                      "is-result": d,
                    },
                  }),
                },
                i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: v,
                      elem: "mount",
                    }),
                  },
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: v,
                        elem: "mount-player",
                      }),
                    },
                    i.a.createElement(
                      "div",
                      {
                        className: tt({
                          block: v,
                          elem: "mount-name",
                        }),
                      },
                      t.playerName
                    ),
                    i.a.createElement(
                      "div",
                      {
                        className: tt({
                          block: v,
                          elem: "mount-avatar",
                        }),
                      },
                      i.a.createElement(
                        ht,
                        {
                          active: b,
                          percent: C(),
                        },
                        i.a.createElement("div", {
                          className: "buddy",
                        })
                      )
                    )
                  ),
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: v,
                        elem: "mount-deck",
                        mods: Object($e.a)(
                          {},
                          "cards-count-" + t.hand.length,
                          !0
                        ),
                      }),
                    },
                    t.hand.map(function (e, n) {
                      return e
                        ? i.a.createElement(nt, {
                            rank: e.rank,
                            suit: e.suit,
                            key: at(n, e),
                            isResult: !0,
                          })
                        : i.a.createElement(nt, {
                            key: at(n),
                            playerId: t.id,
                            handId: n,
                            chosen: y(n),
                            setChosenCard: s,
                            isResult: !0,
                            player: !0,
                          });
                    })
                  ),
                  c &&
                    i.a.createElement(
                      "div",
                      null,
                      i.a.createElement(
                        "div",
                        {
                          className: tt({
                            block: v,
                            elem: "mount-win",
                          }),
                        },
                        "Win:",
                        " ",
                        i.a.createElement(
                          "span",
                          {
                            className: tt({
                              block: v,
                              elem: "mount-win-percent",
                            }),
                          },
                          t.win || "0%"
                        )
                      ),
                      i.a.createElement(
                        "div",
                        {
                          className: tt({
                            block: v,
                            elem: "mount-tie",
                          }),
                        },
                        "Tie:",
                        " ",
                        i.a.createElement(
                          "span",
                          {
                            className: tt({
                              block: v,
                              elem: "mount-tie-percent",
                            }),
                          },
                          t.tie || "0%"
                        )
                      )
                    )
                )
              )
            : i.a.createElement(
                "div",
                {
                  className: tt({
                    block: v,
                    mods: {
                      active: !!a,
                      "no-community-cards": !!p,
                      "is-poc": !!c,
                      "is-result": !!d,
                      slider: !!m,
                    },
                  }),
                  onClick: function (e) {
                    return (function (e) {
                      r(
                        "player",
                        t.id,
                        e.target.className && e.target.className.match(vt)
                      ),
                        u && u(!0);
                    })(e);
                  },
                },
                i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: v,
                      elem: "mount",
                    }),
                  },
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: v,
                        elem: "mount-name",
                      }),
                    },
                    t.playerName
                  ),
                  c &&
                    i.a.createElement(
                      i.a.Fragment,
                      null,
                      i.a.createElement(
                        "div",
                        {
                          className: tt({
                            block: v,
                            elem: "mount-win",
                          }),
                        },
                        h ? "WinHi:" : "Win:",
                        " ",
                        i.a.createElement(
                          "span",
                          {
                            className: tt({
                              block: v,
                              elem: "mount-win-percent",
                            }),
                          },
                          t.win || "0%"
                        )
                      ),
                      h &&
                        i.a.createElement(
                          "div",
                          {
                            className: tt({
                              block: v,
                              elem: "mount-winlo",
                            }),
                          },
                          "WinLo:",
                          " ",
                          i.a.createElement(
                            "span",
                            {
                              className: tt({
                                block: v,
                                elem: "mount-winlo-percent",
                              }),
                            },
                            t.winLo || "0%"
                          )
                        ),
                      !h &&
                        i.a.createElement(
                          "div",
                          {
                            className: tt({
                              block: v,
                              elem: "mount-tie",
                            }),
                          },
                          "Tie:",
                          " ",
                          i.a.createElement(
                            "span",
                            {
                              className: tt({
                                block: v,
                                elem: "mount-tie-percent",
                              }),
                            },
                            t.tie || "0%"
                          )
                        )
                    ),
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: v,
                        elem: "mount-avatar",
                      }),
                    },
                    i.a.createElement(
                      ht,
                      {
                        active: b,
                        percent: C(),
                      },
                      i.a.createElement("div", {
                        className: "buddy",
                      })
                    )
                  ),
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: v,
                        elem: "mount-deck",
                        mods: Object($e.a)(
                          {},
                          "cards-count-" + t.hand.length,
                          !0
                        ),
                      }),
                    },
                    t.hand.map(function (e, a) {
                      return e
                        ? i.a.createElement(nt, {
                            rank: e.rank,
                            suit: e.suit,
                            removeCard: n,
                            key: at(a, e),
                            playerId: t.id,
                            handId: a,
                            chosen: k(a, e),
                            setChosenCard: s,
                            player: !0,
                          })
                        : i.a.createElement(nt, {
                            key: at(a),
                            playerId: t.id,
                            handId: a,
                            chosen: y(a),
                            setChosenCard: s,
                            player: !0,
                          });
                    })
                  )
                )
              );
        },
        gt =
          (n(879),
          function (e) {
            var t = e.winner,
              n = t.name,
              a = t.combination,
              s = t.cards,
              o = e.clickOutside,
              c = "notification",
              l = Object(r.useRef)(null);
            return (
              it(o || !1, l),
              i.a.createElement(
                "div",
                {
                  className: c,
                },
                i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: c,
                      elem: "info-wrapper",
                    }),
                  },
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: c,
                        elem: "title",
                      }),
                    },
                    n
                  ),
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: c,
                        elem: "combination",
                      }),
                    },
                    a
                  )
                ),
                i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: c,
                      elem: "cards-wrapper",
                    }),
                  },
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: c,
                        elem: "cards-info",
                      }),
                    },
                    "Winning hand"
                  ),
                  i.a.createElement(
                    "div",
                    {
                      ref: l,
                      className: tt({
                        block: c,
                        elem: "cards",
                      }),
                    },
                    s &&
                      s.map(function (card, t) {
                        return (
                          card &&
                          i.a.createElement(nt, {
                            rank: card.rank,
                            suit: card.suit,
                            key: at(t, card),
                            result: !0,
                          })
                        );
                      })
                  )
                )
              )
            );
          }),
        yt = n(359),
        kt = function (e) {
          var t = e.map(function (e) {
            return !!e.win && parseFloat(e.win);
          });
          return Math.max.apply(Math, Object(yt.a)(t));
        },
        Ct = function (e, t, n, a) {
          return (
            !!(
              (t.id === n.id + 1 && "player" === n.type) ||
              (a && a.ids.includes(t.id))
            ) && n
          );
        },
        Ot = n(93),
        Et =
          (n(880),
          Object(Ot.f)(
            function (e) {
              var t = e.removeCard,
                n = e.activeField,
                a = e.setActiveField,
                s = e.setChosenCard,
                o = e.isNotWinnerPlayer,
                c = e.isPOC,
                l = e.isWinnerCard,
                d = e.setCardsMenu,
                u = e.noCommunityCards,
                m = e.hiLo,
                f = e.players,
                p = e.isSlidesOverflow,
                h = e.winner,
                v = e.carouselStore,
                b = e.currentSlide,
                g = e.isSplitPotWinner,
                y = e.isOddsWinner,
                k = e.carousel,
                C = e.setBoardCarousel,
                O = st(b),
                E = v.getStoreState(),
                N = st(E);
              Object(r.useEffect)(
                function () {
                  var e = E.totalSlides;
                  if ((N && N.totalSlides) > e)
                    switch (e) {
                      case 2:
                        v.setStoreState({
                          currentSlide: 0,
                        });
                        break;
                      default:
                        3 === E.visibleSlides
                          ? v.setStoreState({
                              currentSlide: e - 3,
                            })
                          : v.setStoreState({
                              currentSlide: e - 2,
                            });
                    }
                },
                [v, b, N, O, E]
              );
              var S = Object(r.useCallback)(
                  function () {
                    return c
                      ? f.find(function (e) {
                          return parseFloat(e.win) === kt(f);
                        })
                      : f.find(function (e) {
                          return h && h.ids.includes(e.id);
                        });
                  },
                  [f, c, h]
                ),
                w = Object(r.useState)(S()),
                A = Object(Qe.a)(w, 2),
                R = A[0],
                F = A[1],
                T = st(S());
              return (
                Object(r.useEffect)(
                  function () {
                    var e = S();
                    if (
                      (k &&
                        k.hasChanged &&
                        k.reset &&
                        (C({
                          hasChanged: !1,
                          reset: !1,
                        }),
                        v.setStoreState({
                          currentSlide: 0,
                        })),
                      e && k && k.hasChanged)
                    )
                      switch (
                        (C({
                          hasChanged: !1,
                        }),
                        E.totalSlides)
                      ) {
                        case 2:
                          v.setStoreState({
                            currentSlide: 0,
                          });
                          break;
                        default:
                          3 === E.visibleSlides
                            ? e.id >= 3
                              ? v.setStoreState({
                                  currentSlide: e.id - 3,
                                })
                              : v.setStoreState({
                                  currentSlide: 0,
                                })
                            : 1 === E.visibleSlides
                            ? v.setStoreState({
                                currentSlide: e.id - 1,
                              })
                            : e.id >= 2
                            ? v.setStoreState({
                                currentSlide: e.id - 2,
                              })
                            : v.setStoreState({
                                currentSlide: 0,
                              });
                      }
                  },
                  [R, F, f, E, T, v, S, k, C]
                ),
                i.a.createElement(
                  i.a.Fragment,
                  null,
                  i.a.createElement(
                    Ot.e,
                    null,
                    f.map(function (e, r) {
                      return i.a.createElement(
                        Ot.d,
                        {
                          index: r,
                          key: e.id,
                          className: tt({
                            block: "board",
                            elem: "slide",
                          }),
                        },
                        i.a.createElement(
                          "div",
                          {
                            className: tt({
                              block: "board",
                              elem: "player",
                              mods: Object($e.a)({}, e.id, !0),
                            }),
                            key: e.id,
                          },
                          i.a.createElement(bt, {
                            player: e,
                            removeCard: t,
                            activeField: Ct(0, e, n, h),
                            splitPotWinner: g(e.id),
                            oddsWinner: y(e.win),
                            isNotWinnerPlayer: o(e),
                            setActiveField: a,
                            setChosenCard: s,
                            isWinnerCard: l,
                            index: r,
                            isPOC: c,
                            noCommunityCards: u,
                            hiLo: m,
                            setCardsMenu: d,
                            slider: !0,
                          })
                        )
                      );
                    })
                  ),
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: "board",
                        elem: "slider-buttons",
                        mods: {
                          visible: p,
                          "is-poc": c,
                        },
                      }),
                    },
                    i.a.createElement(Ot.a, {
                      className: tt({
                        block: "board",
                        elem: "slider-back-button",
                        mods: {
                          "is-poc": c,
                        },
                      }),
                    }),
                    i.a.createElement(Ot.b, {
                      className: tt({
                        block: "board",
                        elem: "slider-next-button",
                        mods: {
                          "is-poc": c,
                        },
                      }),
                    })
                  )
                )
              );
            },
            function (e) {
              return {
                currentSlide: e.currentSlide,
              };
            }
          )),
        Nt = function (e) {
          var t = e.players,
            n = e.visibleSlides,
            a = e.isPOC,
            r = e.isSlidesOverflow;
          return i.a.createElement(
            Ot.c,
            {
              naturalSlideWidth: 1,
              naturalSlideHeight: 1,
              totalSlides: t.length,
              visibleSlides: n,
              className: tt({
                block: "board",
                elem: "slider-players",
                mods: {
                  "is-poc": a,
                  "less-height": !r,
                },
              }),
            },
            i.a.createElement(Et, e)
          );
        },
        St =
          (n(881),
          function (e) {
            var t = e.players,
              n = e.table,
              a = e.winner,
              s = e.removeCard,
              o = (e.hints, e.closeHint, e.activeField),
              c = e.setActiveField,
              l = e.setChosenCard,
              d = e.calculateOdds,
              m = e.getWinnerHand,
              f = (e.activeRules, e.reset),
              p = e.setCardsMenu,
              h = e.setWinner,
              v = e.isPOC,
              b = e.noCommunityCards,
              g = e.hiLo,
              y = e.isWinnerCard,
              k = e.isNotWinnerPlayer,
              C = e.getVisibleSlides,
              O = e.getCurrentSlide,
              E = e.isSplitPotWinner,
              N = e.isOddsWinner,
              S = e.isCardChosen,
              w = e.setBoardCarousel,
              A = e.carousel,
              R = e.isMobile,
              F = e.setCursorPointer,
              T = "board",
              I = Object(r.useRef)(null),
              H = Object(r.useState)(window.innerWidth),
              j = Object(Qe.a)(H, 2),
              x = j[0],
              P = j[1],
              L = C(x),
              J = t.length > L,
              K = O(L);
            Object(r.useEffect)(function () {
              var e = ft()(function () {
                return P(window.innerWidth);
              }, 100);
              return (
                window.addEventListener("resize", e),
                function () {
                  window.removeEventListener("resize", e);
                }
              );
            });
            var W = Object(r.useState)(!1),
              B = Object(Qe.a)(W, 2),
              M = B[0],
              D = B[1];
            it(function () {
              return D(!1);
            }, I);
            var U = Object(r.useState)(K),
              _ = Object(Qe.a)(U, 2),
              G = _[0],
              V = _[1];
            Object(r.useEffect)(
              function () {
                V(K);
              },
              [G, o, K]
            );
            var Q = function () {
                c("table", 1, !0), p && p(!0);
              },
              z = function () {
                return {
                  "is-poc": v,
                };
              },
              Y = function (e) {
                return Object($e.a)({}, e, !0);
              },
              q = function () {
                return {
                  "community-cards": !b,
                };
              };
            return (
              F(R && (!!a || M)),
              i.a.createElement(
                "div",
                {
                  className: tt({
                    block: T,
                  }),
                },
                i.a.createElement(
                  "div",
                  {
                    className: tt({
                      block: T,
                      elem: "wrapper",
                    }),
                  },
                  i.a.createElement(
                    "div",
                    {
                      className: tt({
                        block: T,
                        elem: "poker-table",
                        mods: Object(u.a)({}, z(), q()),
                      }),
                    },
                    v &&
                      i.a.createElement(
                        "div",
                        {
                          className: tt({
                            block: T,
                            elem: "poker-table-dealer",
                          }),
                        },
                        "Dealer"
                      ),
                    n &&
                      i.a.createElement(
                        "div",
                        {
                          className: tt({
                            block: T,
                            elem: "poker-table-cards",
                            mods: Object(u.a)({}, z(), q()),
                          }),
                        },
                        n.flop &&
                          i.a.createElement(
                            "div",
                            {
                              className: tt({
                                block: T,
                                elem: "poker-table-flop",
                                mods: Object(u.a)({}, z(), q()),
                              }),
                            },
                            n.flop.map(function (e, t) {
                              return i.a.createElement(nt, {
                                key: e + t,
                                handId: t,
                                rank: e.rank,
                                suit: e.suit,
                                removeCard: s,
                                setChosenCard: l,
                                chosen: S("flop", e, t),
                                updateActiveField: Q,
                                type: "flop",
                                board: !0,
                              });
                            })
                          ),
                        void 0 !== n.turn &&
                          i.a.createElement(
                            "div",
                            {
                              className: tt({
                                block: T,
                                elem: "poker-table-turn",
                                mods: Object(u.a)({}, z(), q()),
                              }),
                            },
                            i.a.createElement(nt, {
                              rank: n.turn.rank,
                              suit: n.turn.suit,
                              removeCard: s,
                              setChosenCard: l,
                              chosen: S("turn", n.turn),
                              type: "turn",
                              updateActiveField: Q,
                              board: !0,
                            })
                          ),
                        void 0 !== n.river &&
                          i.a.createElement(
                            "div",
                            {
                              className: tt({
                                block: T,
                                elem: "poker-table-river",
                              }),
                            },
                            i.a.createElement(nt, {
                              rank: n.river.rank,
                              suit: n.river.suit,
                              removeCard: s,
                              setChosenCard: l,
                              type: "river",
                              updateActiveField: Q,
                              chosen: S("river", n.river),
                              board: !0,
                            })
                          ),
                        v &&
                          !b &&
                          i.a.createElement(
                            "div",
                            {
                              className: tt({
                                block: T,
                                elem: "poker-table-river",
                                mods: Object(u.a)({}, z(), q()),
                              }),
                            },
                            i.a.createElement(nt, {
                              type: "river",
                              board: !0,
                              disable: !0,
                            })
                          )
                      )
                  ),
                  i.a.createElement(
                    et.a,
                    {
                      query: "(max-width: 834px)",
                    },
                    function (e) {
                      return e
                        ? i.a.createElement(Nt, {
                            players: t,
                            visibleSlides: L,
                            isPOC: v,
                            currentSlide: G,
                            setCurrentSlide: V,
                            activeField: o,
                            isNotWinnerPlayer: k,
                            winner: a,
                            setActiveField: c,
                            setChosenCard: l,
                            isWinnerCard: y,
                            noCommunityCards: b,
                            hiLo: g,
                            setCardsMenu: p,
                            removeCard: s,
                            isSplitPotWinner: E,
                            isOddsWinner: N,
                            isSlidesOverflow: J,
                            carousel: A,
                            setBoardCarousel: w,
                          })
                        : i.a.createElement(
                            "div",
                            {
                              className: tt({
                                block: T,
                                elem: "players",
                                mods: z(),
                              }),
                            },
                            t.map(function (e, t) {
                              var n = e.id;
                              return i.a.createElement(
                                "div",
                                {
                                  className: tt({
                                    block: T,
                                    elem: "player",
                                    mods: Y(n),
                                  }),
                                  key: n,
                                },
                                i.a.createElement(bt, {
                                  player: e,
                                  removeCard: s,
                                  activeField: Ct(0, e, o, a),
                                  noCommunityCards: b,
                                  hiLo: g,
                                  splitPotWinner: E(n),
                                  oddsWinner: N(e.win),
                                  setActiveField: c,
                                  setChosenCard: l,
                                  isNotWinnerPlayer: k(e),
                                  isWinnerCard: y,
                                  index: t,
                                  isPOC: v,
                                })
                              );
                            })
                          );
                    }
                  ),
                  R &&
                    i.a.createElement(
                      i.a.Fragment,
                      null,
                      i.a.createElement(
                        "div",
                        {
                          className: tt({
                            block: T,
                            elem: "buttons-wrapper",
                          }),
                        },
                        i.a.createElement(
                          lt,
                          {
                            click: function () {
                              return v ? d(J && D) : m(V);
                            },
                            type: "blue",
                          },
                          v ? "Calculate Odds" : "Which Hand Wins?"
                        ),
                        i.a.createElement(
                          lt,
                          {
                            click: f,
                            type: "grey",
                          },
                          v ? "Reset cards" : "Reset"
                        )
                      ),
                      M &&
                        i.a.createElement(
                          "div",
                          {
                            className: tt({
                              block: T,
                              elem: "poc-notification",
                              mods: z(),
                            }),
                          },
                          i.a.createElement(
                            "div",
                            {
                              className: tt({
                                block: T,
                                elem: "result-players",
                              }),
                              ref: I,
                            },
                            t.map(function (e, t) {
                              return i.a.createElement(
                                "div",
                                {
                                  className: tt({
                                    block: T,
                                    elem: "player",
                                  }),
                                  key: e.id,
                                },
                                i.a.createElement(bt, {
                                  player: e,
                                  index: t,
                                  isPOC: v,
                                  isResult: !0,
                                })
                              );
                            })
                          )
                        )
                    ),
                  a &&
                    i.a.createElement(
                      "div",
                      {
                        className: tt({
                          block: T,
                          elem: "notification",
                        }),
                      },
                      i.a.createElement(gt, {
                        winner: a,
                        clickOutside:
                          R &&
                          function () {
                            h(!1),
                              w({
                                hasChanged: !1,
                              });
                          },
                      })
                    )
                )
              )
            );
          }),
        wt = Object(c.b)(
          function (e) {
            return (function (e) {
              var t = e.settings.toJS(),
                n =
                  e.board.get("activeField") &&
                  e.board.get("activeField").toJS(),
                a = e.board.get("winner") && e.board.get("winner").toJS(),
                r = e.board.get("carousel") && e.board.get("carousel").toJS(),
                i = e.board.get("players").toJS(),
                s = "poc" === t.id,
                o = z(t.rules).rules,
                c = o.noCommunityCards,
                l = o.hiLo,
                d = function (e) {
                  return (
                    !!a &&
                    a.cards.find(function (t) {
                      return t.suit.id === e.suit.id && t.rank.id === e.rank.id;
                    })
                  );
                };
              return {
                table: e.board.get("table").toJS(),
                hints: e.hints.get("hints").toJS(),
                activeField: n,
                players: i,
                winner: a,
                carousel: r,
                settings: t,
                activeRules: o,
                isPOC: s,
                noCommunityCards: c,
                hiLo: l,
                isWinnerCard: d,
                isNotWinnerPlayer: function (e) {
                  return !(!a || a.ids.includes(e.id));
                },
                getVisibleSlides: function (e) {
                  var t = i[0].hand.length;
                  return e > 550 && t < 4 && i.length >= 3
                    ? 3
                    : e <= 500 && t >= 6
                    ? 1
                    : e <= 400 && t >= 4
                    ? 1
                    : 2;
                },
                getCurrentSlide: function (e) {
                  return !n.type && i.length > 2
                    ? 0
                    : i.length <= e || 0 === n.id
                    ? 0
                    : s
                    ? n.id - 1
                    : n.id + 1 === i.length
                    ? n.id - 2
                    : n.id - 1;
                },
                isSplitPotWinner: function (e) {
                  return a && a.ids.length > 1 && a.ids.includes(e);
                },
                isOddsWinner: function (e) {
                  return parseFloat(e) === kt(i) && n;
                },
                isCardChosen: function (e, t, a) {
                  return (
                    ("flop" === n.card.type
                      ? n.card.type === e && n.card.id === a
                      : n.card.type === e) || d(t)
                  );
                },
              };
            })(e);
          },
          function (e) {
            return {
              removeCard: function (t, n, a) {
                e(ze(t, n, a)), e(Ye(t, n, !0));
              },
              closeHint: function (t) {
                e(qe(t));
              },
              setActiveField: function (t, n, a) {
                e(
                  (function (e, t, n) {
                    return {
                      type: "SET_ACTIVE_FIELD",
                      payload: {
                        type: e,
                        id: t,
                        isCardClicked: n,
                      },
                    };
                  })(t, n, a)
                );
              },
              setBoardCarousel: function (t) {
                e({
                  type: O,
                  payload: t,
                });
              },
              setChosenCard: function (t, n) {
                e(Xe(t, n));
              },
              calculateOdds: function (t) {
                e(Ze(t));
              },
              getWinnerHand: function () {
                e({
                  type: "GET_WINNER_HAND",
                });
              },
              setWinner: function (t) {
                e(
                  (function (e, t) {
                    return {
                      type: setWinner,
                      payload: {
                        winner: t,
                      },
                    };
                  })()
                );
              },
              reset: function () {
                e({
                  type: "RESET",
                });
              },
            };
          }
        )(St),
        At = n(64),
        Rt = n(121),
        Ft = n(362),
        Tt = n(358),
        It = n(47),
        Ht = n(361),
        jt = n(186),
        xt = n.n(jt),
        Pt =
          (n(882),
          (function (e) {
            function t(e) {
              var a;
              Object(At.a)(this, t),
                ((a = Object(Ft.a)(this, Object(Tt.a)(t).call(this, e))).state =
                  {
                    isImgLoaded: !1,
                    isWindowLoaded: !1,
                    isAppLoaded: !1,
                    elapsed: 0,
                  }),
                (a.tick = a.tick.bind(Object(It.a)(a))),
                (a.timer = setInterval(a.tick, 10));
              var r = a.onImgLoad.bind(Object(It.a)(a));
              (a.handleWindowLoad = a.handleWindowLoad.bind(Object(It.a)(a))),
                (a.handleAppLoad = a.handleAppLoad.bind(Object(It.a)(a)));
              var i = n(883),
                s = i.keys().map(function (e) {
                  return i(e);
                }),
                o = [];
              return (
                [xt.a].reverse().forEach(function (e) {
                  var t = s.indexOf(e);
                  -1 !== t && s.splice(t, 1), s.push(e);
                }),
                s.reverse(),
                s.forEach(function (e) {
                  var t = new Image();
                  t.setAttribute("path", e),
                    (t.src = e),
                    o.push(t),
                    t.addEventListener("load", function () {
                      var e = s.indexOf(this.getAttribute("path"));
                      -1 !== e
                        ? s.splice(e, 1)
                        : console.log(
                            "Image was not founded: " +
                              this.getAttribute("path")
                          ),
                        0 === s.length && r();
                    });
                }),
                a
              );
            }
            return (
              Object(Ht.a)(t, e),
              Object(Rt.a)(t, [
                {
                  key: "onImgLoad",
                  value: function () {
                    this.setState({
                      isImgLoaded: !0,
                    }),
                      this.handleAppLoad();
                  },
                },
                {
                  key: "tick",
                  value: function () {
                    this.setState({
                      elapsed: new Date() - this.props.start,
                    });
                  },
                },
                {
                  key: "componentDidMount",
                  value: function () {
                    window.addEventListener("load", this.handleWindowLoad);
                  },
                },
                {
                  key: "handleWindowLoad",
                  value: function () {
                    this.setState({
                      isWindowLoaded: !0,
                    }),
                      this.handleAppLoad();
                  },
                },
                {
                  key: "handleAppLoad",
                  value: function () {
                    var e = this;
                    if (this.state.isImgLoaded && this.state.isWindowLoaded) {
                      var t = (
                        Math.round(this.state.elapsed / 100) / 10
                      ).toFixed(1);
                      t < 2
                        ? setTimeout(function () {
                            return e.handleAppLoad();
                          }, 1e3 * (2 - t))
                        : (this.setState({
                            isAppLoaded: !0,
                          }),
                          clearInterval(this.timer));
                    }
                  },
                },
                {
                  key: "render",
                  value: function () {
                    var e = {
                      app: {
                        visibility: this.state.isAppLoaded
                          ? "visible"
                          : "hidden",
                        height: "100%",
                      },
                      loader: {
                        display: this.state.isAppLoaded ? "none" : "flex",
                      },
                    };
                    return i.a.createElement(
                      "div",
                      {
                        style: {
                          height: "100%",
                        },
                      },
                      i.a.createElement(
                        "div",
                        {
                          style: e.app,
                        },
                        this.props.children
                      ),
                      i.a.createElement(
                        "div",
                        {
                          className: "loader",
                          style: e.loader,
                        },
                        i.a.createElement(
                          "div",
                          {
                            className: "loader-content_wrapper",
                          },
                          i.a.createElement(
                            "div",
                            {
                              className: "logo-container",
                            },
                            i.a.createElement("img", {
                              src: xt.a,
                              alt: "",
                            })
                          ),
                          i.a.createElement("div", {
                            className: "lds-dual-ring",
                          })
                        )
                      )
                    );
                  },
                },
              ]),
              t
            );
          })(i.a.PureComponent)),
        Lt = function () {
          var e = Object(r.useState)(!1),
            t = Object(Qe.a)(e, 2),
            n = t[0],
            a = t[1],
            s = Object(r.useState)(!1),
            o = Object(Qe.a)(s, 2),
            c = o[0],
            l = o[1],
            d = function () {
              return l(window.innerWidth <= 834);
            },
            u = Object(r.useState)(!1),
            m = Object(Qe.a)(u, 2),
            f = m[0],
            p = m[1];
          return (
            Object(r.useEffect)(
              function () {
                document.getElementsByTagName("body")[0].style.cursor = f
                  ? "pointer"
                  : "default";
              },
              [f]
            ),
            Object(r.useEffect)(function () {
              var e = function (e) {
                var t = document.getElementsByClassName(
                    "board__poc-notification"
                  )[0],
                  n = document.getElementsByClassName(
                    "menu__choose-main-block"
                  )[0],
                  a = n && n.contains(e.target);
                (t && t.contains(e.target)) || a || e.preventDefault();
              };
              return (
                document.getElementsByClassName("App")[0].offsetHeight <=
                  document.body.offsetHeight &&
                  (document.body.addEventListener("touchmove", e, {
                    passive: !1,
                  }),
                  (document.ontouchmove = e)),
                d(),
                window.addEventListener("resize", d),
                function () {
                  return window.removeEventListener("resize", d);
                }
              );
            }, []),
            i.a.createElement(
              Pt,
              {
                start: Date.now(),
              },
              i.a.createElement(
                "div",
                {
                  className: tt({
                    block: "App",
                    mods: {
                      clickable: !!f,
                    },
                  }),
                },
                i.a.createElement(ut, {
                  setCardsMenu: a,
                  cardsMenu: n,
                  isMobile: c,
                }),
                i.a.createElement(wt, {
                  setCardsMenu: a,
                  isMobile: c,
                  setCursorPointer: p,
                })
              )
            )
          );
        };
      Boolean(
        "localhost" === window.location.hostname ||
          "[::1]" === window.location.hostname ||
          window.location.hostname.match(
            /^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/
          )
      );
      var Jt = document.getElementById("root");
      o.a.render(
        i.a.createElement(
          c.a,
          {
            store: Ve,
          },
          i.a.createElement(Lt, null)
        ),
        Jt
      ),
        "serviceWorker" in navigator &&
          navigator.serviceWorker.ready.then(function (e) {
            e.unregister();
          });
    },
    932: function (e, t, n) {
      "use strict";
      n.r(t);
      var a = n(64),
        r = n(121),
        i = n(9),
        s = n.n(i),
        o = ["2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"],
        c = ["A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K"],
        l = ["s", "h", "d", "c"],
        rankNme = {
          2: {
            singular: "Two",
            plural: "Deuces",
          },
          3: {
            singular: "Three",
            plural: "Treys",
          },
          4: {
            singular: "Four",
            plural: "Fours",
          },
          5: {
            singular: "Five",
            plural: "Fives",
          },
          6: {
            singular: "Six",
            plural: "Sixes",
          },
          7: {
            singular: "Seven",
            plural: "Sevens",
          },
          8: {
            singular: "Eight",
            plural: "Eights",
          },
          9: {
            singular: "Nine",
            plural: "Nines",
          },
          T: {
            singular: "Ten",
            plural: "Tens",
          },
          J: {
            singular: "Jack",
            plural: "Jacks",
          },
          Q: {
            singular: "Queen",
            plural: "Queens",
          },
          K: {
            singular: "King",
            plural: "Kings",
          },
          A: {
            singular: "Ace",
            plural: "Aces",
          },
        },
        u = {
          s: {
            singular: "spade",
            plural: "spades",
          },
          h: {
            singular: "heart",
            plural: "hearts",
          },
          d: {
            singular: "diamond",
            plural: "diamonds",
          },
          c: {
            singular: "club",
            plural: "clubs",
          },
        };

      function m(e, t) {
        var n = s.a.indexOf(o, e.rank);
        return s.a.indexOf(o, t.rank) - n;
      }

      function f(e, t) {
        var n = m(e, t);
        return n > 0 ? -1 : n < 0 ? 1 : 0;
      }

      function p(e, t) {
        var n = s.a.indexOf(c, e.rank),
          a = s.a.indexOf(c, t.rank) - n;
        return a > 0 ? -1 : a < 0 ? 1 : 0;
      }
      var cardRank = (function () {
          var rankFunc = function (e, t) {
            if (1 === arguments.length)
              if (s.a.isString(arguments[0]))
                (this.rank = arguments[0].substring(0, 1)),
                  (this.suit = arguments[0].substring(1, 2));
              else if (s.a.isArray(arguments[0]))
                (this.rank = arguments[0][0]), (this.suit = arguments[0][1]);
              else {
                var n = s.a.extend({}, e);
                (this.rank = n.rank), (this.suit = n.suit);
              }
            else {
              if (2 !== arguments.length)
                throw Error("invalid number of arguments");
              (this.rank = e), (this.suit = t);
            }
            if (!s.a.contains(o, this.rank)) throw Error("invalid rank");
            if (!s.a.contains(l, this.suit)) throw Error("invalid suit");
          };
          return (
            (rankFunc.RANKS = o),
            (rankFunc.ACE_LOW_RANKS = c),
            (rankFunc.SUITS = l),
            (rankFunc.SUIT_SPADE = "s"),
            (rankFunc.SUIT_HEART = "h"),
            (rankFunc.SUIT_DIAMOND = "d"),
            (rankFunc.SUIT_CLUB = "c"),
            (rankFunc.RANK_TWO = "2"),
            (rankFunc.RANK_THREE = "3"),
            (rankFunc.RANK_FOUR = "4"),
            (rankFunc.RANK_FIVE = "5"),
            (rankFunc.RANK_SIX = "6"),
            (rankFunc.RANK_SEVEN = "7"),
            (rankFunc.RANK_EIGHT = "8"),
            (rankFunc.RANK_NINE = "9"),
            (rankFunc.RANK_TEN = "T"),
            (rankFunc.RANK_JACK = "J"),
            (rankFunc.RANK_QUEEN = "Q"),
            (rankFunc.RANK_KING = "K"),
            (rankFunc.RANK_ACE = "A"),
            (rankFunc.sortCards = function (e, t) {
              void 0 === t && (t = !0);
              var n = s.a.extend([], e);
              return t ? n.sort(f) : n.sort(p), n;
            }),
            (rankFunc.compare = function (e, t) {
              return f(e, t);
            }),
            (rankFunc.compareAceLow = function (e, t) {
              return p(e, t);
            }),
            (rankFunc.greaterThan = function (e, t) {
              return 1 === f(e, t);
            }),
            (rankFunc.lessThan = function (e, t) {
              return -1 === f(e, t);
            }),
            (rankFunc.distance = function (e, t) {
              return m(e, t);
            }),
            (rankFunc.singularRankName = function (e) {
              return rankNme[e.rank].singular;
            }),
            (rankFunc.pluralRankName = function (e) {
              return rankNme[e.rank].plural;
            }),
            (rankFunc.singularSuitName = function (e) {
              return u[e.suit].singular;
            }),
            (rankFunc.pluralSuitName = function (e) {
              return u[e.suit].plural;
            }),
            (rankFunc.objectifyCards = function (e) {
              return s.a.map(e, function (e) {
                return new cardRank(e);
              });
            }),
            rankFunc
          );
        })(),
        v = {
          type: "Royal Flush",
          validate: function (e, t, n, a) {
            return !a && e[0].rank === cardRank.RANK_ACE && t && n;
          },
          description: function (e) {
            return "Royal Flush";
          },
        },
        b = {
          type: "Straight Flush",
          validate: function (e, t, n, a) {
            return !a && !(e[0].rank === cardRank.RANK_ACE) && t && n;
          },
          description: function (e) {
            return (
              "Straight Flush, " + cardRank.singularRankName(e[0]) + "-High"
            );
          },
        },
        g = {
          type: "Four of a kind",
          validate: function (e) {
            return j(e, [4, 1]);
          },
          description: function (e) {
            return "Four of a kind, " + cardRank.pluralRankName(e[0]);
          },
        },
        y = {
          type: "Full House",
          validate: function (e) {
            return j(e, [3, 2]);
          },
          description: function (e) {
            return (
              "Full House " +
              cardRank.pluralRankName(e[0]) +
              " full of " +
              cardRank.pluralRankName(e[3])
            );
          },
        },
        k = {
          type: "flush",
          validate: function (e, t, n, a) {
            return !a && !t && n;
          },
          description: function (e) {
            return "Flush, " + cardRank.singularRankName(e[0]) + " High";
          },
        },
        C = {
          type: "straight",
          validate: function (e, t, n, a) {
            return !a && t && !n;
          },
          description: function (e) {
            return "Straight, " + cardRank.singularRankName(e[0]) + " High";
          },
        },
        O = {
          type: "three of a kind",
          validate: function (e) {
            return j(e, [3, 1, 1]);
          },
          description: function (e) {
            return "Three of a kind, " + cardRank.pluralRankName(e[0]);
          },
        },
        E = {
          type: "two pair",
          validate: function (e) {
            return j(e, [2, 2, 1]);
          },
          description: function (e) {
            return (
              "Two pairs " +
              cardRank.pluralRankName(e[0]) +
              " and " +
              cardRank.pluralRankName(e[2])
            );
          },
        },
        N = {
          type: "pair",
          validate: function (e) {
            return j(e, [2, 1, 1, 1]);
          },
          description: function (e) {
            return "Pair of " + cardRank.pluralRankName(e[0]);
          },
        },
        S = {
          type: "high card",
          validate: function (e, t, n, a) {
            var r = j(e, [1, 1, 1, 1, 1]);
            return a ? r : r && !t && !n;
          },
          description: function (e) {
            return cardRank.singularRankName(e[0]) + "-High";
          },
        },
        w = {};
      (w["Royal Flush"] = v),
        (w["Straight Flush"] = b),
        (w["Four of a kind"] = g),
        (w["Full House"] = y),
        (w.flush = k),
        (w.straight = C),
        (w["three of a kind"] = O),
        (w["two pair"] = E),
        (w.pair = N),
        (w["high card"] = S);
      var A = [
        "Royal Flush",
        "Straight Flush",
        "Four of a kind",
        "Full House",
        "flush",
        "straight",
        "three of a kind",
        "two pair",
        "pair",
        "high card",
      ];

      function R(e, t, n) {
        n || (n = cardRank.compare);
        var a = s.a.indexOf(A, e.ranking),
          r = s.a.indexOf(A, t.ranking) - a;
        if (r > 0) return 1;
        if (r < 0) return -1;
        for (var i = 0; i < 5; i++) {
          var o = n(e.cards[i], t.cards[i]);
          if (0 !== o)
            return (e.kicker = e.cards[i]), (t.kicker = t.cards[i]), o;
        }
        return 0;
      }

      function F(e, t) {
        return R(e, t, cardRank.compare);
      }

      function T(e, t) {
        return R(e, t, cardRank.compareAceLow);
      }
      var I = (function () {
        var e = function (e, t, n) {
          if (5 !== e.length)
            throw Error("hand ranking is found using five cards");
          if (!w[t]) throw Error("hand ranking not valid");
          n ||
            (n = {
              formed: !1,
            }),
            (this.cards = n.formed ? e : H(cardRank.objectifyCards(e), n)),
            (this.hasStraight =
              void 0 === n.hasStraight ? x(this.cards) : n.hasStraight),
            (this.hasFlush =
              void 0 === n.hasFlush ? P(this.cards) : n.hasFlush),
            (this.onlyPairsCount =
              void 0 !== n.onlyPairsCount && n.onlyPairsCount),
            (this.aceHigh = void 0 === n.aceHigh || n.aceHigh),
            (this.ranking = t),
            (this.cards = (function (e, t) {
              for (
                var n = [],
                  a = function (t) {
                    (i = s.a.filter(e, function (n) {
                      var a = 0;
                      return (
                        e.forEach(function (e) {
                          e.rank === n.rank && a++;
                        }),
                        a === t
                      );
                    })),
                      n.push(i);
                  },
                  r = 4;
                r > 0;
                r--
              ) {
                var i;
                a(r);
              }
              return s.a.flatten(n);
            })(this.cards)),
            (this.isValid = function () {
              return w[this.ranking].validate(
                this.cards,
                this.hasStraight,
                this.hasFlush,
                this.onlyPairsCount
              );
            }),
            (this.description = w[this.ranking].description(this.cards));
        };
        return (
          (e.ROYAL_FLUSH = "Royal Flush"),
          (e.STRAIGHT_FLUSH = "Straight Flush"),
          (e.FOUR_OF_A_KIND = "Four of a kind"),
          (e.FULL_HOUSE = "Full House"),
          (e.FLUSH = "flush"),
          (e.STRAIGHT = "straight"),
          (e.THREE_OF_A_KIND = "three of a kind"),
          (e.TWO_PAIR = "two pair"),
          (e.PAIR = "pair"),
          (e.HIGH_CARD = "high card"),
          (e.HAND_RANKINGS = [
            "Royal Flush",
            "Straight Flush",
            "Four of a kind",
            "Full House",
            "flush",
            "straight",
            "three of a kind",
            "two pair",
            "pair",
            "high card",
          ]),
          (e.compareHandRankings = R),
          (e.compareAceHighHandRankings = F),
          (e.compareAceLowHandRankings = T),
          (e.containsStraight = x),
          (e.containsFlush = P),
          (e.formCards = H),
          (e.eightOrBetter = L),
          (e.sortHandRankings = function (e, t) {
            void 0 === t && (t = !0);
            var n = t ? F : T;
            return s.a.extend([], e).sort(n);
          }),
          e
        );
      })();

      function H(e, t) {
        return (
          void 0 === t &&
            (t = {
              onlyPairsCount: !1,
              aceHigh: !0,
            }),
          (function (e) {
            var t = e[0].rank === cardRank.RANK_ACE,
              n = e[1].rank === cardRank.RANK_FIVE,
              a = e[2].rank === cardRank.RANK_FOUR,
              r = e[3].rank === cardRank.RANK_THREE,
              i = e[4].rank === cardRank.RANK_TWO;
            return t && n && a && r && i;
          })((e = cardRank.sortCards(e, t.aceHigh).reverse())) &&
            !t.onlyPairsCount &&
            (e = [e[1], e[2], e[3], e[4], e[0]]),
          e
        );
      }

      function j(e, t) {
        var n = s.a.uniq(s.a.pluck(e, "rank")),
          a = [];
        return (
          n.forEach(function (t) {
            var n = s.a.where(e, {
              rank: t,
            }).length;
            a.push(n);
          }),
          a.join(",") === t.join(",")
        );
      }

      function x(e) {
        return (
          (function (e) {
            for (var t = 1; t < e.length; t++) {
              var n = e[t - 1],
                a = e[t],
                r = -1 === cardRank.distance(n, a);
              if (!r) return !1;
            }
            return !0;
          })(e) ||
          (function (e) {
            var t = e[0].rank === cardRank.RANK_FIVE,
              n = e[1].rank === cardRank.RANK_FOUR,
              a = e[2].rank === cardRank.RANK_THREE,
              r = e[3].rank === cardRank.RANK_TWO;
            return e[4].rank === cardRank.RANK_ACE && t && n && a && r;
          })(e)
        );
      }

      function P(e) {
        for (var t = e[0].suit, n = 0; n < e.length; n++) {
          if (e[n].suit !== t) return !1;
        }
        return !0;
      }

      function L(e) {
        var t = j(e.cards, [1, 1, 1, 1, 1]),
          n = e.cards[0],
          a = new cardRank(cardRank.RANK_EIGHT, cardRank.SUIT_CLUB);
        return 1 !== cardRank.compareAceLow(n, a) && t;
      }
      var J = n(609),
        K = (cardRank.RANKS, cardRank.RANKS, "high"),
        W = "low",
        B = "hi/lo",
        M = {
          winType: K,
          aceHigh: !0,
          onlyPairsCount: !1,
          omaha: !1,
          eightOrBetter: !1,
        },
        D = {
          winType: K,
          aceHigh: !0,
          onlyPairsCount: !1,
          omaha: !0,
          eightOrBetter: !1,
        },
        U = {
          winType: W,
          aceHigh: !1,
          onlyPairsCount: !0,
          omaha: !0,
          eightOrBetter: !0,
        },
        _ = {
          winType: W,
          aceHigh: !1,
          onlyPairsCount: !0,
          omaha: !1,
          eightOrBetter: !0,
        },
        G = {
          winType: W,
          aceHigh: !0,
          onlyPairsCount: !1,
          omaha: !1,
          eightOrBetter: !1,
        },
        V = {
          winType: W,
          aceHigh: !1,
          onlyPairsCount: !0,
          omaha: !1,
          eightOrBetter: !1,
        },
        Q = {
          "Texas Holdem": M,
          "Omaha Hi": D,
          "Omaha Hi/Lo": {
            winType: B,
            aceHigh: !0,
            onlyPairsCount: !1,
            omaha: !0,
            eightOrBetter: !0,
          },
          Stud: M,
          "Stud Hi/Lo": {
            winType: B,
            aceHigh: !0,
            onlyPairsCount: !1,
            omaha: !1,
            eightOrBetter: !0,
          },
          Razz: V,
          "Kansas City Lowball": G,
          "California Lowball": V,
          "Deuce to Seven": G,
          "Deuce to Six": {
            winType: W,
            aceHigh: !0,
            onlyPairsCount: !0,
            omaha: !1,
            eightOrBetter: !1,
          },
          "Ace to Six": {
            winType: W,
            aceHigh: !1,
            onlyPairsCount: !1,
            omaha: !1,
            eightOrBetter: !1,
          },
        };

      function z(e, t, n) {
        return (function (e, t) {
          var n = t.winType === K;
          if (
            (e.sort(function (e, a) {
              var r = (
                t.aceHigh
                  ? I.compareAceHighHandRankings
                  : I.compareAceLowHandRankings
              )(e.handRanking, a.handRanking);
              return n ? r : -1 * r;
            }),
            t.eightOrBetter &&
              0 ===
                (e = s.a.filter(e, function (e) {
                  return I.eightOrBetter(e.handRanking);
                })).length)
          )
            return !1;
          for (var a = 0, r = 0, i = [[Y(e[0])]], o = 1; o < e.length; o++) {
            var c = e[o],
              l = e[o - 1],
              d = t.aceHigh
                ? I.compareAceHighHandRankings
                : I.compareAceLowHandRankings,
              u = d(c.handRanking, l.handRanking),
              m = Y(c);
            c.handRanking.description === l.handRanking.description &&
              (function () {
                var e = void 0,
                  t = void 0,
                  n = void 0,
                  s = !1;
                c.handRanking.kicker &&
                  ((e = c.handRanking.kicker.rank),
                  (t = c.handRanking.kicker.suit)),
                  l.handRanking.kicker &&
                    ((n = l.handRanking.kicker.rank),
                    (s = l.handRanking.kicker.suit)),
                  c.handRanking.cards.filter(function (n) {
                    return e && n.rank === e && n.suit === t;
                  }).length > 0 && (m.highKicker = c.handRanking.kicker),
                  l.handRanking.cards.filter(function (e) {
                    return n && e.rank === n && e.suit === s;
                  }).length > 0 && (i[a][r].highKicker = l.handRanking.kicker);
              })(),
              0 === u
                ? (s.a.last(i).push(m), (r += 1))
                : (i.push([m]), (a += 1), (r = 0));
          }
          return i.reverse();
        })(
          s.a.map(e, function (e) {
            return {
              id: e.id,
              cards: e.cards,
              board: t,
              handRanking: q(e.cards, t, n),
            };
          }),
          n
        );
      }

      function Y(e) {
        return {
          id: e.id,
          ranking: e.handRanking.ranking,
          cards: e.cards,
          board: e.board,
          playingCards: e.handRanking.cards,
          description: e.handRanking.description,
          highKicker: !1,
        };
      }

      function q(e, t, n) {
        if (!n.omaha) return Z(e.concat(t), n);
        var a = s.a.map(
            (function (e, t) {
              var n = J.find(e, 2),
                a = J.find(t, 3),
                r = [];
              return (
                s.a.each(n, function (e) {
                  s.a.each(a, function (t) {
                    r.push(e.concat(t));
                  });
                }),
                r
              );
            })(e, t),
            function (e) {
              return Z(e, n);
            }
          ),
          r = I.sortHandRankings(a, n.aceHigh);
        return n.winType === K
          ? s.a.last(r)
          : n.winType === W
          ? s.a.first(r)
          : void 0;
      }

      function Z(e, t) {
        var n = J.find(e, 5),
          a = s.a.map(n, function (e) {
            return (function (e, t) {
              for (
                var n = I.HAND_RANKINGS,
                  a = I.formCards(e, t),
                  r = I.containsStraight(a),
                  i = I.containsFlush(a),
                  s = n.length - 1;
                s >= 0;
                s--
              ) {
                var o = n[s],
                  c = {
                    hasStraight: r,
                    hasFlush: i,
                    formed: !0,
                    onlyPairsCount: t.onlyPairsCount,
                    aceHigh: t.aceHigh,
                  },
                  l = new I(a, o, c);
                if (l.isValid()) return l;
              }
              throw Error("no hand ranking was found");
            })(e, t);
          }),
          r = I.sortHandRankings(a, t.aceHigh);
        return t.winType === K
          ? s.a.last(r)
          : t.winType === W
          ? s.a.first(r)
          : void 0;
      }
      var X = n(106);
      n.d(t, "AVAILABLE_GAMES", function () {
        return $;
      }),
        n.d(t, "AVAILABLE_RESULT", function () {
          return ee;
        }),
        n.d(t, "Game", function () {
          return te;
        });
      var $ = ["Texas Holdem", "Omaha Hi", "Razz"],
        ee = ["WIN", "SPLIT"],
        te = (function () {
          function e(t, n, r) {
            Object(a.a)(this, e),
              (this.players = t),
              (this.board = n),
              (this.gameType = r),
              (this.result = (function (e, t, n, a) {
                if (!$.includes(n)) throw Error("Unsupported game type");
                var r = [],
                  i = [];
                return (
                  e.forEach(function (e) {
                    var t = [];
                    e.hand.cards.forEach(function (e) {
                      t.push(e.rank + e.suit);
                    }),
                      r.push({
                        id: e.id,
                        cards: t,
                      });
                  }),
                  t.cards.forEach(function (e) {
                    i.push(e.rank + e.suit);
                  }),
                  (function (e, t, n) {
                    var a = [],
                      r = M;
                    if (
                      (s.a.isArray(t)
                        ? ((a = t), s.a.isString(n) && (r = Q[n]))
                        : s.a.isString(t) && (r = Q[t]),
                      !r)
                    )
                      throw Error("Unsupported Game Type");
                    if (
                      ((e = s.a.map(e, function (e) {
                        return {
                          id: e.id,
                          cards: cardRank.objectifyCards(e.cards),
                        };
                      })),
                      (a = cardRank.objectifyCards(a)),
                      r.winType === B)
                    ) {
                      var i = r.omaha
                        ? {
                            high: D,
                            low: U,
                          }
                        : {
                            high: M,
                            low: _,
                          };
                      return {
                        high: z(e, a, i.high),
                        low: z(e, a, i.low),
                      };
                    }
                    return z(e, a, r);
                  })(r, i, n)
                );
              })(t, n, r));
          }
          return (
            Object(r.a)(e, [
              {
                key: "getTypeOfResult",
                value: function () {
                  return 1 === this.result[0].length ? "win" : "split";
                },
              },
              {
                key: "getWinners",
                value: function () {
                  for (
                    var e = this.result[0],
                      t = function (e) {
                        return e.map(function (e) {
                          return new X.Card(e.rank, e.suit);
                        });
                      },
                      n = [],
                      a = 1;
                    a < this.result.length;
                    a++
                  )
                    this.result[a - 1][0].description ===
                      this.result[a][0].description &&
                      (n.includes(a - 1) || n.push(a - 1), n.push(a));
                  return {
                    resultType: this.getTypeOfResult(),
                    winnerResult: e.map(function (a) {
                      var r = a.description;
                      return (
                        a.highKicker &&
                          (1 === e.length || n.includes(0)) &&
                          (r +=
                            ", " +
                            X.Card.getNameByRank(a.highKicker.rank) +
                            " kicker"),
                        {
                          playerId: a.id,
                          cards: t(a.cards),
                          board: t(a.board),
                          result: t(a.playingCards),
                          handName: r,
                          ranking: a.ranking,
                        }
                      );
                    }),
                    allResults: this.result.map(function (a, r) {
                      return a.map(function (a) {
                        var i = a.description;
                        return (
                          a.highKicker &&
                            (1 === e.length || n.includes(r)) &&
                            (i +=
                              ", " +
                              X.Card.getNameByRank(a.highKicker.rank) +
                              " kicker"),
                          {
                            playerId: a.id,
                            cards: t(a.cards),
                            board: t(a.board),
                            result: t(a.playingCards),
                            handName: i,
                            ranking: a.ranking,
                          }
                        );
                      });
                    }),
                  };
                },
              },
            ]),
            e
          );
        })();
    },
  },
  [[363, 1, 2]],
]);
