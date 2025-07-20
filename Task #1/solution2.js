const args = process.argv.slice(2);
if (!args.length) return console.log();

const allContain = (substr) => args.every(str => str.includes(substr));

const s = args[0];
let low = 0, high = s.length, res = "";

while (low <= high) {
    const mid = Math.floor((low + high) / 2);
    let found = false;
    const set = new Set();

    for (let i = 0; i + mid <= s.length; i++)
        set.add(s.slice(i, i + mid));

    for (const sub of set) {
        if (allContain(sub)) {
            found = true;
            res = sub;
            break;
        }
    }

    if (found) low = mid + 1;
    else high = mid - 1;
}

console.log(res);