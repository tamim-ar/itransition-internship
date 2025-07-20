import zipfile
import hashlib

zip_path = r'Task #2\task2_3.zip'
email = 'tamimahasan.ar@gmail.com'.lower()

with zipfile.ZipFile(zip_path, 'r') as z:
    files = [f for f in z.namelist() if not f.endswith('/')]
    assert len(files) == 256, f'Expected 256 files, found {len(files)}'

    hashes = [
        hashlib.sha3_256(z.read(name)).hexdigest().lower()
        for name in files
    ]

final_data = ''.join(sorted(hashes, reverse=True)) + email
final_hash = hashlib.sha3_256(final_data.encode()).hexdigest().lower()

print(f'Final hash: {final_hash}')
print(f'Submit with: !task2 {email} {final_hash}')
