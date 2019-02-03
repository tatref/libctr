#!/usr/bin/env python3
#
# Prints some data about level files
#
# Example usage:
#  * install kaitai-struct for python
#     pip install kaitaistruct
#
#  * you can now run this script to parse level files
#    ./print_level_objects.py /path/to/.lev

#  * or if the python lib is not in the current dir
#    PYTHONPATH=../python ./parse_bigfile_example.py /path/to/.lev
#
# Sample output:
#   file: data/bigfile/001_canyon_1P.lev
#   
#   c
#    mesh_ptr: 0x65520
#    ax, ay, az: 3264,2304,-5659
#   
#   t
#    mesh_ptr: 0x65150
#    ax, ay, az: 13447,1536,7754
#   
#   r
#    mesh_ptr: 0x6493c
#    ax, ay, az: 3865,3073,4373
#   
#   cactus_saguro#2
#    mesh_ptr: 0x64534
#    ax, ay, az: 3117,2304,-4730
#   ...
#
#


import sys
import os

try:
    import kaitaistruct
except Exception as e:
    print('kaitaistruct not found')
    print(e)
    sys.exit(1)
try:
    from ctr.ctr_level import CtrLevel
except Exception as e:
    print(e)
    print('re-run with `PYTHONPATH=../python ./print_level_objects.py`')
    sys.exit(1)


if len(sys.argv) != 2:
    print('Usage: ' + sys.argv[0] + ' </path/to/.lev>')
    sys.exit(1)

lvl_filename = sys.argv[1]


# parse the file
lvl = CtrLevel.from_file(lvl_filename)


print('file: ' + str(lvl_filename))
print()

for obj in lvl.header.objects_index:
    inst = obj.object_instance
    print(inst.name)
    print(' mesh_ptr: ' + hex(inst.mesh_ptr))
    print(' ax, ay, az: ' + '{},{},{}'.format(inst.ax, inst.ay, inst.az))
    print()

    # unknown pointers table in mesh
    #try:
    #    for ptr in obj.object_instance.object_mesh.table_ptr:
    #        print(' ' + hex(ptr))
    #except:
    #    print('out of bounds')
    #    pass


print('\nDone')
