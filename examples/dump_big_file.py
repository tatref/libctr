#!/usr/bin/env python3
#
# CTR BIGFILE.BIG dumper
#
# Example usage:
#  * install kaitai-struct for python
#     pip install kaitaistruct
#
#  * you can now run this script to parse you BIGFILE.BIG
#    ./parse_bigfile_example.py /path/to/BIGFILE.BIG /tmp/dump

#  * or if the python lib is not in the current dir
#    PYTHONPATH=../python ./parse_bigfile_example.py /path/to/BIGFILE.BIG /tmp/dump
#
#


from pprint import pprint
import hashlib
import json
import os
import sys
from pathlib import Path


try:
    import kaitaistruct
except Exception as e:
    print('kaitaistruct not found')
    print(e)
    sys.exit(1)

# try to import the kaitai libs, depending on cwd
sys.path.append('../python')
sys.path.append('./python')
try:
    from ctr.ctr_bigfile import CtrBigfile
except Exception as e:
    print('ctr not found')
    print('re-run with `PYTHONPATH=../python ./dump_big_file.py`')
    print(e)
    sys.exit(1)


if len(sys.argv) != 3:
    print('Usage: ' + sys.argv[0] + ' </path/to/BIGFILE.BIG> <dump path>')
    sys.exit(1)

bigfile = sys.argv[1]
dump_path = Path(sys.argv[2])

bigfiles = {
        '03a005e2abc6022fd1e1e7405300ad77': 'SCES-02105',
        'c43eba5a20f0b4fc69a00c8d61a8ec10': 'SCUS-94426',
        }


with open(bigfile, 'rb') as bigfile_reader:
    h = hashlib.md5()
    h.update(bigfile_reader.read())
    md5sum = h.hexdigest()
    bigfile_version = bigfiles[md5sum]


filenames_path = os.path.dirname(os.path.abspath(__file__)) + '/filenames_' + bigfile_version + '.txt'


filenames = {}
for line in open(filenames_path).readlines():
    line = line.strip()
    num = int(line.split('=')[0])
    name = line.split('=')[1]
    filenames[num] = { 'name': name }

try:
    os.mkdir(str(dump_path))
except:
    print('Unable to create path ' + str(dump_path))
    pass

# parse the file
# we can also use `from_bytes` to parse from in-memory files
ctr = CtrBigfile.from_file(bigfile)


print('BIGFILE contains {} entries'.format(ctr.files_count))


print('md5 idx filename')
# actual dump
for idx, entry in enumerate(ctr.index):
    content = entry.file_content

    if idx in filenames:
        output_filename = dump_path / Path('{:03d}'.format(idx) + '_' + filenames[idx]['name'])
    else:
        output_filename = dump_path / '{:03d}'.format(idx)
        filenames[idx] = {}

    with output_filename.open('wb') as bigfile_writer:
        bigfile_writer.write(content)

    # compute md5
    h = hashlib.md5()
    h.update(content)
    md5sum = h.hexdigest()

    filenames[idx]['md5'] = md5sum
    print(md5sum, idx, output_filename)


with (dump_path / Path('../bigfile_' + bigfile_version + '.json')).open('w') as filenames_writer:
    json.dump(filenames, filenames_writer, sort_keys=True, indent=4)


print('\nDone')
