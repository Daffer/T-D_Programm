#ifndef IMAGE_H
#define IMAGE_H
#include <QImage>
#include <QPixmap>
#include <QGraphicsScene>
#include <QGraphicsView>
#include <QGraphicsScene>
#include <QImage>
#include <QPixmap>
#include <QRgb>
#include <QPainter>
#include <stack>
#include "tparticle.h"

class My_Image
{
public:
    My_Image();
    void negativ();
    void brightness(int n);
    void contrast(int n);
    void otsu();
    void handy_binarization(int t);
    void convert();
    void back_conv();
    void erode();
    void dilate();
    void check_erode_dilate();
    void morpho_border_correct();
    int make_cart();
    void make_border();
    int make_calculations();
    void set_is_saved(int n);
    int check_border();

    void zatravka(int x,int y,QImage *im,int h,int w);

    void operator = (My_Image right);

    int is_saved;
    bool is_binary;

    int matr_height;
    int matr_width;

    double rate;

    TParticle *particles;
    QPixmap pix;
    int **matr;
};

/*void My_Image::operator =(My_Image right)
{
    int i,j;
    this->pix = right.pix;
    this->matr_height = right.matr_height;
    this->matr_width = right.matr_width;
    for (i=0;i<pix.width();i++)
    {
        for (j=0;j<pix.height();j++)
        {
            this->matr[i][j] = right.matr[i][j];
        }
    }
}*/


#endif // IMAGE_H
