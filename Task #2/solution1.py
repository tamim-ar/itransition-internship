import zipfile
import hashlib

zip_path = r'Task #2\task2_3.zip'
email = 'tamimahasan.ar@gmail.com'

with zipfile.ZipFile(zip_path, 'r') as zip_file:
    file_list = [f for f in zip_file.namelist() if not f.endswith('/')]
    if len(file_list) != 256:
        raise ValueError(f'Expected 256 files, found {len(file_list)}')

    hashes = []
    for file_name in file_list:
        with zip_file.open(file_name) as f:
            data = f.read()
            hash_hex = hashlib.sha3_256(data).hexdigest().lower()
            hashes.append(hash_hex)

    sorted_hashes = sorted(hashes, reverse=True)
    concatenated = ''.join(sorted_hashes)
    final_string = concatenated + email.lower()
    final_hash = hashlib.sha3_256(final_string.encode('utf-8')).hexdigest().lower()

print(f'Final hash: {final_hash}')
print(f'Submit with: !task2 {email.lower()} {final_hash}')
