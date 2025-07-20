let a = process.argv.slice(2);
if (!a.length) console.log();
else {
    let s = a[0], n = s.length;
    for (let l = n; l > 0; l--)
        for (let i = 0; i + l <= n; i++) {
            let sub = s.slice(i, i + l);
            if (a.every(x => x.includes(sub))) {
                console.log(sub);
                process.exit();
            }
        }
    console.log();
}