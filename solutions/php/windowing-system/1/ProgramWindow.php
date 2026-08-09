<?php

class ProgramWindow
{
    public $y;
    public $x;
    public $height;
    public $width;

    public function __construct()
    {
        $this->y = 0;
        $this->x = 0;
        $this->height = 600;
        $this->width = 800;
    }

    public function resize($size = new Size(600, 800))
    {
        $this->height = $size->height;
        $this->width = $size->width;
    }

    public function move($position = new Position(0, 0))
    {
        $this->x = $position->x;
        $this->y = $position->y;
    }

}
