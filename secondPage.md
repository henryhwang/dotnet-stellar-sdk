## This is a sample page
# Markdown heading 1
## markdown heading 2
### markdown heading 3
## markdown heading 2

>this is a qoute

~~~
GET /deposit
~~~

### markdown heading 3
> this block qoute is here for your information

~~~csharp {.line-numbers, highlight=7-9}
using system;

public class ABC
{
    public int myMethod(string s, int i)
    {
        if(string.IsNullOrEmpty(s)) i = 0;
        else i = 1;
        return i;
    }
}
~~~

- [x] @mentions, #refs, [links](), **formatting**, and <del>tags</del> supported
- [ ] list syntax required
- [x] this is a complete item
- [ ] this is an incomplete item


```sequence {theme="hand"}
Andrew->China: says hello
Note right of China: China thinks\nabout it
China->Andrew: how are you?
Note left of Andrew: humm...
Andrew->China: I am good, thanks!
```

```flow
st=>start: Start:>http://www.google.com[blank]
e=>end:>http://www.google.com
op1=>operation: My Op
sub1=>subroutine: My subR
cond=>condition: Yes
or No?:>http://www.google.com
io=>inputoutput: cath something...

st->op1->cond
cond(yes)->io->e
cond(no)->sub1(right)->op1
```

```bash {cmd}
ls .
```

```javascript {cmd="node"}
const date = Date.now()
console.log(date.toString())
```

```python {cmd="c:/windows/py.exe" matplotlib=true}
import matplotlib.pyplot as plt
plt.plot([1,2,3, 4])
plt.show() # show figure
```
