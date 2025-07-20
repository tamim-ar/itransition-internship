import crypto from 'crypto';
import AdmZip from 'adm-zip';

const zipPath = 'Task #2/task2_3.zip';
const email = 'sabilarrahman36@gmail.com'.toLowerCase();

const zip = new AdmZip(zipPath);
const zipEntries = zip.getEntries().filter(e => !e.isDirectory);

if (zipEntries.length !== 256) {
  throw new Error(`Expected 256 files, found ${zipEntries.length}`);
}

const hashes = zipEntries.map(entry => {
  const data = entry.getData();
  return crypto.createHash('sha3-256').update(data).digest('hex').toLowerCase();
});

const sortedHashes = hashes.sort((a, b) => (a < b ? 1 : -1));
const concatenated = sortedHashes.join('') + email;
const finalHash = crypto.createHash('sha3-256').update(concatenated).digest('hex').toLowerCase();

console.log(`Final hash: ${finalHash}`);
console.log(`Submit with: !task2 ${email} ${finalHash}`);
