# Introduction
This a library to parse CTR data files

# Status
## Done or mostly done
* [BIGFILE.BIG](./kaitai-struct/ctr_bigfile.ksy)
* [TIM files](./kaitai-struct/psx_tim.ksy)
* [lang](./kaitai-struct/ctr_lang.ksy)

# Building
## Requirements
* clone this repo

```
git clone https://github.com/tatref/libctr
cd libctr/
```

* Install java
* Install kaitai-struct-compiler-0.8 (see http://kaitai.io/#download for details)

```
wget https://dl.bintray.com/kaitai-io/universal/0.8/kaitai-struct-compiler-0.8.zip
unzip kaitai-struct-compiler-0.8.zip
```

* Install graphviz (optional). For visual block diagrams

## Building the libs
The source for each file format is at `./kaitai-struct`. To build, the Python/Java/... libs from it, just run

```
./create_libs.sh
```

# Usage
TODO


# Gallery
## Block diagrams
![CTR Bigfile](./graphviz/ctr_bigfile.png "CTR Bigfile")

## Web IDE (https://ide.kaitai.io/)
Level
![CTR Level](./gallery/web_ide_ctr_level.png "CTR Level")

Character
![CTR Character](./gallery/web_ide_ctr_character.png "CTR Character")


