#!/usr/bin/env python3
#
# BIGFILE.BIG dumper
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


import sys
import os

try:
    import kaitaistruct
except Exception as e:
    print('kaitaistruct not found')
    sys.exit(1)
try:
    from ctr.ctr_bigfile import CtrBigfile
except Exception as e:
    print('ctr not found')
    print('re-run with `PYTHONPATH=../python ./dump_big_file.py`')
    sys.exit(1)


if len(sys.argv) != 3:
    print('Usage: ' + sys.argv[0] + ' </path/to/BIGFILE.BIG> <dump path>')
    sys.exit(1)

bigfile = sys.argv[1]
dump_path = sys.argv[2]

try:
    os.mkdir(dump_path)
except:
    pass

# parse the file
# we can also use `from_bytes` to parse from in-memory files
ctr = CtrBigfile.from_file(bigfile)


print('BIGFILE contains {} entries'.format(ctr.files_count))


# actual dump
for idx, entry in enumerate(ctr.index):
    print(idx)

    content = entry.file_content

    output_filename = dump_path + os.path.sep + '{:03d}'.format(idx)
    destination = open(output_filename, 'wb')
    destination.write(content)


print('\nDone')
