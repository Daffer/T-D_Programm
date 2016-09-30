#include "image.h"
#include "math.h"
#include <stack>
using namespace std;
My_Image::My_Image(){
   // pix.load("im.jpg");

}
void My_Image::set_is_saved(int n){
    is_saved = n;
}
int Zatravka(int x,int y,unsigned int num, int **m,int h,int w)
{
    int i,j,Square = 0;
    unsigned int old_num;
    stack<int> sti;    stack<int> stj;
    sti.push(x);  stj.push(y);
    old_num = m[x][y];

    do
    {
        i=sti.top(); j=stj.top();
        sti.pop();    stj.pop();

        if (m[i][j] != num)
        {
            m[i][j] = num;
            Square++;
        }

        if (i<h-1)
            if (m[i+1][j] == old_num)
            {
                sti.push(i+1);  stj.push(j);
                m[i+1][j] = num;
                Square++;
            }
        if (i>0)
            if (m[i-1][j] == old_num)
            {
                sti.push(i-1);  stj.push(j);
                m[i-1][j] = num;
                Square++;
            }

        if (j<w-1)
            if (m[i][j+1] == old_num)
            {
                sti.push(i);  stj.push(j+1);
                m[i][j+1] = num;
                Square++;
            }
        if (j>0)
            if (m[i][j-1] == old_num)
            {
                sti.push(i);  stj.push(j-1);
                m[i][j-1] = num;
                Square++;
            }

    }
    while (sti.empty() != true);
    return Square;
}
void My_Image::zatravka(int x, int y, QImage *im,int h,int w)
{
    int i,j;
    stack<int> sti;    stack<int> stj;
    sti.push(x);  stj.push(y);

    do
    {
        i=sti.top(); j=stj.top();
        sti.pop();stj.pop();

        (*im).setPixel(i,j,qRgb(255,255,255));
        if (i-1>=0)
        {
            int r = qRed((*im).pixel(i-1,j));
            int g = qGreen((*im).pixel(i-1,j));
            int b = qBlue((*im).pixel(i-1,j));
            float y=(r+g+b)/3;
            if (y!=255)//((r==0)&&(g==0)&&(b==0))
            {
                sti.push(i-1);
                stj.push(j);
            }
        }
        if (j-1>=0)
        {
            int r = qRed((*im).pixel(i,j-1));
            int g = qGreen((*im).pixel(i,j-1));
            int b = qBlue((*im).pixel(i,j-1));
            float y=(r+g+b)/3;
            if (y!=255)//((r==0)&&(g==0)&&(b==0))
            {
                sti.push(i);
                stj.push(j-1);
            }
        }
        if (i+1<h)
        {
            int r = qRed((*im).pixel(i+1,j));
            int g = qGreen((*im).pixel(i+1,j));
            int b = qBlue((*im).pixel(i+1,j));
            float y=(r+g+b)/3;
            if (y!=255)//((r==0)&&(g==0)&&(b==0))
            {
                sti.push(i+1);
                stj.push(j);
            }
        }
        if (j+1<w)
        {
            int r = qRed((*im).pixel(i,j+1));
            int g = qGreen((*im).pixel(i,j+1));
            int b = qBlue((*im).pixel(i,j+1));
            float y=(r+g+b)/3;
            if (y!=255)//((r==0)&&(g==0)&&(b==0))
            {
                sti.push(i);
                stj.push(j+1);
            }
        }

        if ((j+1<w)&&(i+1<h))
        {
            int r = qRed((*im).pixel(i+1,j+1));
            int g = qGreen((*im).pixel(i+1,j+1));
            int b = qBlue((*im).pixel(i+1,j+1));
            float y=(r+g+b)/3;
            if (y!=255)//((r==0)&&(g==0)&&(b==0))
            {
                sti.push(i+1);
                stj.push(j+1);
            }
        }
        if ((j-1>=0)&&(i+1<h))
        {
            int r = qRed((*im).pixel(i+1,j-1));
            int g = qGreen((*im).pixel(i+1,j-1));
            int b = qBlue((*im).pixel(i+1,j-1));
            float y=(r+g+b)/3;
            if (y!=255)//((r==0)&&(g==0)&&(b==0))
            {
                sti.push(i+1);
                stj.push(j-1);
            }
        }
        if ((j+1<w)&&(i-1>=0))
        {
            int r = qRed((*im).pixel(i-1,j+1));
            int g = qGreen((*im).pixel(i-1,j+1));
            int b = qBlue((*im).pixel(i-1,j+1));
            float y=(r+g+b)/3;
            if (y!=255)//((r==0)&&(g==0)&&(b==0))
            {
                sti.push(i-1);
                stj.push(j+1);
            }
        }
        if ((j-1>=0)&&(i-1>=0))
        {
            int r = qRed((*im).pixel(i-1,j-1));
            int g = qGreen((*im).pixel(i-1,j-1));
            int b = qBlue((*im).pixel(i-1,j-1));
            float y=(r+g+b)/3;
            if (y!=255)//((r==0)&&(g==0)&&(b==0))
            {
                sti.push(i-1);
                stj.push(j-1);
            }
        }
    }
    while (sti.empty() != true);
}
void My_Image::make_border()
{
    int i,j;
    FILE *t=fopen("bord.txt","w");
    QImage image(pix.toImage());

    for (j=0;j<image.height();j++)
    {
        int r = qRed(image.pixel(0,j));
        int g = qGreen(image.pixel(0,j));
        int b = qBlue(image.pixel(0,j));
        fprintf(t,"%d %d %d ",r,g,b);
        float y = (r+g+b)/3;
        if (y!=255)//((r==0)&&(g==0)&&(b==0))
        {
            zatravka(0,j,&image,image.width(),image.height());
        }
        //convert();
       // back_conv();
        r = qRed(image.pixel(1,j));
        g = qGreen(image.pixel(1,j));
        b = qBlue(image.pixel(1,j));
        fprintf(t,"%d %d %d \n",r,g,b);
        y = (r+g+b)/3;
        if (y!=255)//((r==0)&&(g==0)&&(b==0))
        {
            zatravka(1,j,&image,image.width(),image.height());
        }

        r = qRed(image.pixel(image.width()-2,j));
        g = qGreen(image.pixel(image.width()-2,j));
        b = qBlue(image.pixel(image.width()-2,j));
        fprintf(t,"%d %d %d \n",r,g,b);
        y = (r+g+b)/3;
        if (y!=255)//((r==0)&&(g==0)&&(b==0))
        {
            zatravka(image.width()-2,j,&image,image.width(),image.height());
        }
        r = qRed(image.pixel(image.width()-1,j));
        g = qGreen(image.pixel(image.width()-1,j));
        b = qBlue(image.pixel(image.width()-1,j));
        fprintf(t,"%d %d %d \n",r,g,b);
        y = (r+g+b)/3;
        if (y!=255)//((r==0)&&(g==0)&&(b==0))
        {
            zatravka(image.width()-1,j,&image,image.width(),image.height());
        }
        //convert();
        //back_conv();
    }
    fprintf(t,"========================\n");
    for (j=0;j<image.width();j++)
    {
        int r = qRed(image.pixel(j,0));
        int g = qGreen(image.pixel(j,0));
        int b = qBlue(image.pixel(j,0));
        fprintf(t,"%d %d %d ",r,g,b);
        float y = (r+g+b)/3;
        if (y!=255)//((r==0)&&(g==0)&&(b==0))
        {
            zatravka(j,0,&image,image.width(),image.height());
        }
        r = qRed(image.pixel(j,1));
        g = qGreen(image.pixel(j,1));
        b = qBlue(image.pixel(j,1));
        fprintf(t,"%d %d %d \n",r,g,b);
        y = (r+g+b)/3;
        if (y!=255)//((r==0)&&(g==0)&&(b==0))
        {
            zatravka(j,1,&image,image.width(),image.height());
        }

        r = qRed(image.pixel(j,image.height()-2));
        g = qGreen(image.pixel(j,image.height()-2));
        b = qBlue(image.pixel(j,image.height()-2));
        fprintf(t,"%d %d %d \n",r,g,b);
        y = (r+g+b)/3;
        if (y!=255)//((r==0)&&(g==0)&&(b==0))
        {
            zatravka(j,image.height()-2,&image,image.width(),image.height());
        }
        r = qRed(image.pixel(j,image.height()-1));
        g = qGreen(image.pixel(j,image.height()-1));
        b = qBlue(image.pixel(j,image.height()-1));
        fprintf(t,"%d %d %d \n",r,g,b);
        y = (r+g+b)/3;
        if (y!=255)//((r==0)&&(g==0)&&(b==0))
        {
            zatravka(j,image.height()-1,&image,image.width(),image.height());
        }
    }
    QPixmap::fromImage(image).save("rab2.bmp");
    pix.load("rab2.bmp");
}

void My_Image::negativ(){
    int i,j;
    QImage image(pix.toImage());
    QPainter paint(&image);
    QPen pen(Qt::blue);
    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            int r,g,b;
            r=qRed(image.pixel(i,j));
            g=qGreen(image.pixel(i,j));
            b=qBlue(image.pixel(i,j));
            r=255-r;g=255-g;b=255-b;

            paint.setPen(QColor(r,g,b));
            paint.drawPoint(i,j);
        }
    }
    QPixmap::fromImage(image).save("rab.bmp");
    pix.load("rab.bmp");
}
int AddColor(int Source,int ChangeVal)
{
 int Check = Source + ChangeVal;
 if (Check > 255) return 255;
 if (Check < 0  ) return 0;
 if ((Check <= 255) && (Check >= 0)) return Check;
}
void My_Image::brightness(int n)
{
    int i,j;
    QImage image(pix.toImage());

    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            int r,g,b;

            r=qRed(image.pixel(i,j));
            g=qGreen(image.pixel(i,j));
            b=qBlue(image.pixel(i,j));

            r = AddColor(r,n);
            g = AddColor(g,n);
            b = AddColor(b,n);
            /*if ((!((r+n>=255)&&(g+n>=255)&&(b+n>=255)))&&(!((r+n<=0)&&(g+n<=0)&&(b+n<=0))))
            {
                r=r+n;g=g+n;b=b+n;
            }*/
            image.setPixel(i,j,qRgb(r,g,b));
        }
    }
    QPixmap::fromImage(image).save("rab2.bmp");
    pix.load("rab2.bmp");
}

int extremate_color(int source,int changeval)
{
    if (changeval > 0)
       {
        if (source > 127)
          {
           int Check = source + changeval;
           if (Check > 255)  return 255;
           else return Check;
          }
        else
          {
           int Check = source - changeval;
           if (Check < 0) return 0;
           else return Check;
          }
       }
     if (changeval <= 0)
       {
        if (source > 127)
          {
           int Check = source + changeval;
           if (Check < 127)  return 127;
           else return Check;
          }
        else
          {
           int Check = source - changeval;
           if (Check > 127) return 127;
           else return Check;
          }
       }
}
int contrast_pixel(int val,int n){
    double pixel;
    double contrast = (100.0 + n)/100.0;

    contrast = contrast*contrast;

    pixel = val / 255.0;
    pixel = pixel - 0.5;
    pixel = pixel * contrast;
    pixel = pixel + 0.5;
    pixel = pixel * 255;
    if (pixel<0) pixel = 0;
    if (pixel>255) pixel = 255;
    return (int)pixel;
}
void My_Image::contrast(int n)
{
    int i,j;
    QImage image(pix.toImage());

    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            int r,g,b;

            r=qRed(image.pixel(i,j));
            g=qGreen(image.pixel(i,j));
            b=qBlue(image.pixel(i,j));

            r = contrast_pixel(r,n);
            g = contrast_pixel(g,n);
            b = contrast_pixel(b,n);

            image.setPixel(i,j,qRgb(r,g,b));
        }
    }
    QPixmap::fromImage(image).save("rab2.bmp");
    pix.load("rab2.bmp");
}
void My_Image::otsu(){
    QImage image(pix.toImage());
    QPainter paint(&image);
    int p[256];
    double pp[256];
    int i,j;
    int vsego=0;
    for (i=0;i<256;i++)
    {
        p[i]=0;
    }
    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            int r,g,b,y;
            r=qRed(image.pixel(i,j));
            g=qGreen(image.pixel(i,j));
            b=qBlue(image.pixel(i,j));
            y=0.299*r+0.587*g+0.114*b;
            p[y]++;
        }
    }
    for (i=0;i<256;i++)
    {
        vsego+=p[i];
    }
    for (i=0;i<256;i++)
    {
        pp[i]=(double)p[i]/(double)vsego;
    }
    int t;
    double q1,q2,m1,m2,s1,s2,sw;
    sw=1000000;
    for (i=0;i<=255;i++)
    {
        q1=0;q2=0;m1=0;m2=0;s1=0;s2=0;
        for (j=0;j<=i;j++)
        {
            q1+=pp[j];
        }
        for (j=i+1;j<=255;j++)
        {
            q2+=pp[j];
        }
        for (j=0;j<=i;j++)
        {
            m1+=j*pp[j]/q1;
        }
        for (j=i+1;j<=255;j++)
        {
            m2+=j*pp[j]/q2;
        }
        for (j=0;j<=i;j++)
        {
            s1+=(j-m1)*(j-m1)*pp[j]/q1;
        }
        for (j=i+1;j<=255;j++)
        {
            s2+=(j-m2)*(j-m2)*pp[j]/q2;
        }
        if ((q1*s1+q2*s2)<sw)
        {
            sw=q1*s1+q2*s2;
            t=i;
        }

    }
    printf("%d\n",t);
    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            int r,g,b,y;
            r=qRed(image.pixel(i,j));
            g=qGreen(image.pixel(i,j));
            b=qBlue(image.pixel(i,j));
            y=0.299*r+0.587*g+0.114*b;
            if (y>t)
            {
                image.setPixel(i,j,qRgb(0,0,0));
            }
            else
            {
                image.setPixel(i,j,qRgb(255,255,255));
            }
        }
    }
    QPixmap::fromImage(image).save("rab2.bmp");
    pix.load("rab2.bmp");
}

void My_Image::convert(){
    int i,j;
    //FILE *f=fopen("rab.txt","w");
    QImage image(pix.toImage());
    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            int r,g,b,y;
            r=qRed(image.pixel(i,j));
            g=qGreen(image.pixel(i,j));
            b=qBlue(image.pixel(i,j));
            y=0.299*r+0.587*g+0.114*b;
            if ((r==0)&&(g==0)&&(b==0))
            {
                matr[i][j]=1;
            }
            else
            {
                matr[i][j]=0;
            }
        }
    }
    /*for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            fprintf(f,"%d",matr[i][j]);
        }
        fprintf(f,"\n");
    }*/
}

void My_Image::back_conv(){
    int i,j;
    //FILE *f=fopen("rab.txt","w");
    QImage image(pix.toImage());
    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            if (matr[i][j]==1)
            {
                image.setPixel(i,j,qRgb(0,0,0));
            }
            else
            if (matr[i][j]==0)
            {
                image.setPixel(i,j,qRgb(255,255,255));
            }
        }
    }
    /*for (i=0;i<image.width();i++)
        {
            for (j=0;j<image.height();j++)
            {
                fprintf(f,"%d",matr[i][j]);
            }
            fprintf(f,"\n");
        }*/
    QPixmap::fromImage(image).save("rab2.bmp");
    pix.load("rab2.bmp");
}

void My_Image::erode(){
    QImage image(pix.toImage());
    int matr2[image.width()][image.height()];
    int filter[3][3];
    int i,j,k,l;
    filter[0][0]=1;
        filter[0][1]=1;
        filter[0][2]=1;
        filter[1][0]=1;
        filter[1][1]=1;
        filter[1][2]=1;
        filter[2][0]=1;
        filter[2][1]=1;
        filter[2][2]=1;
   /* filter[-1][-1]=1;
    filter[-1][0]=1;
    filter[-1][1]=1;
    filter[0][-1]=1;
    filter[0][0]=1;
    filter[0][1]=1;
    filter[1][-1]=1;
    filter[1][0]=1;
    filter[1][1]=1;*/
    for (i=1;i<image.width()-3;i++)//erode
    {
       for (j=1;j<image.height()-3;j++)
       {
           int count=0;
           k=-1;l=-1;
           while (((1*matr[i+k][j+l])!=0)&&(k<2))
           {
               count++;
               if (l<1)
               {
                   l++;
               }
               else
               {
                   l=-1;
                   k++;
               }
           }
           if (count==9)
           {
               matr2[i][j]=1;
           }
           else
               matr2[i][j]=0;
       }//end erode
    }
    for (i=1;i<image.width()-1;i++)//erode
    {
       for (j=1;j<image.height()-1;j++)
       {
           matr[i][j]=matr2[i][j];
       }
    }
}

void My_Image::dilate(){
    int i,j,k,l;
    QImage image(pix.toImage());
    int g,b;
    g=pix.width();
    b=pix.height();

    printf("%d\n",pix.width());

    int matr2[pix.width()][pix.height()];
    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            matr2[i][j]=0;
        }
    }
    int filter[3][3];

    filter[0][0]=1;
        filter[0][1]=1;
        filter[0][2]=1;
        filter[1][0]=1;
        filter[1][1]=1;
        filter[1][2]=1;
        filter[2][0]=1;
        filter[2][1]=1;
        filter[2][2]=1;

        for (i=1;i<pix.width()-1;i++)//dilation
        {
           for (j=1;j<pix.height()-1;j++)
           {
               int rez=0;
               for (k=-1;k<=1;k++)
               {
                   for (l=-1;l<=1;l++)
                   {
                       rez+=1*matr[i+k][j+l];
                   }
               }
               if (rez>0)
                  matr2[i][j]=1;
               else
                  matr2[i][j]=0;
           }//dilation end
        }
        for (i=1;i<pix.width()-1;i++)//erode
        {
           for (j=1;j<pix.height()-1;j++)
           {
               matr[i][j]=matr2[i][j];
           }
        }
}

void My_Image::check_erode_dilate(){
    int i,j;
    QImage image(pix.toImage());
    for (i=0;i<image.height();i++)
    {
        for (j=0;j<image.height();j++)
        {
            if ((matr[i][j]!=0)&&(matr[i][j]!=1))
                matr[i][j]=0;
        }
    }
}

void My_Image::morpho_border_correct()
{
    int i,j;
    QImage image(pix.toImage());
    for (i=0;i<image.height();i++)
    {
        matr[0][i]=0;
        matr[1][i]=0;
        matr[image.width()-1][i]=0;
        matr[image.width()-2][i]=0;
    }
    for (i=0;i<image.width();i++)
    {
        matr[i][0]=0;
        matr[i][1]=0;
        matr[i][image.height()-1]=0;
        matr[i][image.height()-2]=0;
    }
    back_conv();
    QPixmap::fromImage(image).save("rab2.bmp");
    pix.load("rab2.bmp");
}

void My_Image::handy_binarization(int t){
    int i,j;
    QImage image(pix.toImage());
    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            int r,g,b,y;
           // int index=pix.toImage().pixelIndex(i,j);
            r=qRed(image.pixel(i,j));
            g=qGreen(image.pixel(i,j));
            b=qBlue(image.pixel(i,j));
            y=0.299*r+0.587*g+0.114*b;
            if (y>t)
            {
                image.setPixel(i,j,qRgb(0,0,0));
            }
            else
            {
                image.setPixel(i,j,qRgb(255,255,255));
            }
        }
    }
    QPixmap::fromImage(image).save("rab2.bmp");
    pix.load("rab2.bmp");
}


bool Is_Border(int **a,int i,int j,int h,int w)
{
    bool is_border=false;
    if ((i>0)&&(a[i-1][j]==0)) is_border=true;
    if ((i<h-1)&&(a[i+1][j]==0)) is_border=true;
    if ((j<w-1)&&(a[i][j+1]==0)) is_border=true;
    if ((j>0)&&(a[i][j-1]==0)) is_border=true;
    return is_border;
}

int Perimetr(int **a,int num,int h, int w)
{
    int i,j;
    int count=0;
    int count_bor=0;

    for (i=0;i<h;i++)
    {
        for (j=0;j<w;j++)
        {
            bool is_border=false;
            if (a[i][j]==num)
            {
                is_border=Is_Border(a,i,j,h,w);
            }

            if (is_border==true)
            {
                count_bor++;
                if ((i>0)&&(j>0)&&(!Is_Border(a,i-1,j,h,w))&&(!Is_Border(a,i,j-1,h,w))) count++;
                if ((i<h-1)&&(j>0)&&(!Is_Border(a,i+1,j,h,w))&&(!Is_Border(a,i,j-1,h,w))) count++;
                if ((i<h-1)&&(j<w-1)&&(!Is_Border(a,i+1,j,h,w))&&(!Is_Border(a,i,j+1,h,w))) count++;
                if ((i>0)&&(j<w-1)&&(!Is_Border(a,i-1,j,h,w))&&(!Is_Border(a,i,j+1,h,w))) count++;
            }
        }
    }
    return (count_bor+count*0.2071);
}
int My_Image::make_cart(){
    int i,j;
    //FILE *f=fopen("rab.txt","w");
    QImage image(pix.toImage());
    if (matr==NULL)
    {
        matr_height = pix.width();
        matr_width = pix.height();
        matr = (int **)malloc(pix.width() * sizeof(int *));
        for(i = 0; i < pix.width(); i++)
        {
           matr[i] = (int *)malloc(pix.height() * sizeof(int));
        }
    }
    int nom=1;
    for (i=0;i<image.width();i++)
    {
        for (j=0;j<image.height();j++)
        {
            if (matr[i][j]==1)
            {
                nom+=1;
                Zatravka(i,j,nom,matr,image.width(),image.height());
                //printf("Object #%d has square of %d\n",nom,Zatravka(i,j,nom,matr,image.height(),image.width()));
            }
        }
    }
    return nom;
}

void calculate_length(int Hei,int Wid,int **Map,int Num,TParticle *Particles)
{
 for (int i=2; i<=Num; i++) Particles[i-2].set_length(0);
 for (int n=2; n<=Num; n++)
    {
     int xlu=Wid,ylu=Hei,xrd=0,yrd=0,xn,yn;
     // находим две точки
     for (int i=0; i<Hei; i++)
        for (int j=0; j<Wid; j++)
           if (Map[i][j] == n)
             {
              if (i < ylu) ylu=i;
              if (i > yrd) yrd=i;
              if (j < xlu) xlu=j;
              if (j > xrd) xrd=j;
             }
     // находим центральную точку фигуры
     xn=(xlu+xrd)/2;
     yn=(ylu+yrd)/2;
     // находим Longsize
     int xl,yl;
     for (int i=ylu; i<=yrd; i++)
        for (int j=xlu; j<=xrd; j++)
           if (Map[i][j] == n)
             {
              float aa = sqrt( (xn-j)*(xn-j) + (yn-i)*(yn-i) );
              if (aa > Particles[n-2].get_length()) Particles[n-2].set_length(aa);
             }
    }
 for (int i=2; i<=Num; i++)
    {
     Particles[i-2].set_length(Particles[i-2].get_length()*2);
     if (Particles[i-2].get_length() == 0) Particles[i-2].set_length(1);
    }
}
void calculate_width(int Hei,int Wid,int **Map,int Num,TParticle *Particles)
{
    for (int i=2; i<=Num; i++) Particles[i-2].set_width(Hei*Wid);
 for (int n=2; n<=Num; n++)
    {
     int xlu=Wid,ylu=Hei,xrd=0,yrd=0,xn,yn;
     // находим две точки
     for (int i=0; i<Hei; i++)
        for (int j=0; j<Wid; j++)
           if (Map[i][j] == n)
             {
              if (i < ylu) ylu=i;
              if (i > yrd) yrd=i;
              if (j < xlu) xlu=j;
              if (j > xrd) xrd=j;
             }
     // находим центральную точку фигуры
     xn=(xlu+xrd)/2;
     yn=(ylu+yrd)/2;
     // находим Shortsize
     for (int i=ylu-1; i<=yrd+1; i++)
        for (int j=xlu-1; j<=xrd+1; j++)
           if (Map[i][j] != n)
             {
              float aa = sqrt((xn-j)*(xn-j) + (yn-i)*(yn-i));
              if (aa < Particles[n-2].get_width()) Particles[n-2].set_width(aa);
             }
    }
 for (int i=2; i<=Num; i++)
    {
     Particles[i-2].set_width(Particles[i-2].get_width()*2);
     if (Particles[i-2].get_width() == 0) Particles[i-2].set_width(1);
    }
}
int My_Image::make_calculations()
{
    FILE *f = fopen("log.txt","w");
    int i,j;
    int nom=1;
    int n_particles = make_cart();
   // if ((particles != NULL)&&(particles[0].get_form_factor()>=0)&&(particles[0].get_form_factor()<=1))
      //  free(particles);
    particles = (TParticle *)malloc(n_particles * sizeof(TParticle));
    for (i=0;i<pix.width();i++)
    {
        for (j=0;j<pix.height();j++)
        {
            if (matr[i][j]>0)
                matr[i][j]=1;
        }
    }
    /*calculation of the squares*/
    for (i=0;i<pix.width();i++)
    {
        for (j=0;j<pix.height();j++)
        {
            if (matr[i][j]==1)
            {
                nom+=1;
                float sq = Zatravka(i,j,nom,matr,pix.width(),pix.height())*rate;
                particles[nom-2].set_square(sq);



            }
        }
    }
    /*calculation of the perimetrs*/
    for (i=2;i<=n_particles;i++)
    {
        float pr = Perimetr(matr,i,pix.width(),pix.height()) *rate;
        //printf("%d %f")
        particles[i-2].set_perimetr(pr);
        //fprintf(f,"%d %f %f ",i,particles[i-2].get_square(),particles[i-2].get_perimetr());
    }

    /*calculation of lengthes*/
    calculate_length(pix.width(),pix.height(),matr,n_particles,particles);
    /*calculation of widthes*/
    calculate_width(pix.width(),pix.height(),matr,n_particles,particles);
    /*calculation of diameters*/
    for (i=2; i<=n_particles; i++)
    {
        particles[i-2].set_diameter(2 * sqrt(particles[i-2].get_square() / 3.14*rate));
        particles[i-2].set_diameterGOST(sqrt(particles[i-2].get_square()*rate));
        particles[i-2].set_form_factor(particles[i-2].get_width() / particles[i-2].get_length());
            if (particles[i-2].get_form_factor() > 1) particles[i-2].set_form_factor(1);
            particles[i-2].set_smoothness( (particles[i-2].get_perimetr() * particles[i-2].get_perimetr()) / (4 * 3.14 * particles[i-2].get_square()));

    }
    for (i=2;i<=n_particles;i++)
    {

        fprintf(f,"%d %f %f %f %f %f %f %f %f %f\n",i,
                particles[i-2].get_square(),
                particles[i-2].get_perimetr(),
                particles[i-2].get_length(),
                particles[i-2].get_width(),
                particles[i-2].get_form_factor(),
                particles[i-2].get_smoothness(),
                particles[i-2].get_width(),
                particles[i-2].get_diameter(),
                particles[i-2].get_diameterGOST());
    }
    fclose(f);
    return n_particles-1;
}
int My_Image::check_border()
{
    int i,j;
    QImage image(pix.toImage());

    for (j=0;j<image.height();j++)
    {
        int r = qRed(image.pixel(0,j));
        int g = qGreen(image.pixel(0,j));
        int b = qBlue(image.pixel(0,j));
        float y = (r+g+b)/3;
        if (y!=255)
        {
            return -1;
        }
        r = qRed(image.pixel(1,j));
        g = qGreen(image.pixel(1,j));
        b = qBlue(image.pixel(1,j));
        y = (r+g+b)/3;
        if (y!=255)
        {
            return -1;
        }

        r = qRed(image.pixel(image.width()-2,j));
        g = qGreen(image.pixel(image.width()-2,j));
        b = qBlue(image.pixel(image.width()-2,j));
        y = (r+g+b)/3;
        if (y!=255)
        {
            return -1;
        }
        r = qRed(image.pixel(image.width()-1,j));
        g = qGreen(image.pixel(image.width()-1,j));
        b = qBlue(image.pixel(image.width()-1,j));
        y = (r+g+b)/3;
        if (y!=255)
        {
            return -1;
        }
    }
    for (j=0;j<image.width();j++)
    {
        int r = qRed(image.pixel(j,0));
        int g = qGreen(image.pixel(j,0));
        int b = qBlue(image.pixel(j,0));
        float y = (r+g+b)/3;
        if (y!=255)
        {
            return -1;
        }
        r = qRed(image.pixel(j,1));
        g = qGreen(image.pixel(j,1));
        b = qBlue(image.pixel(j,1));
        y = (r+g+b)/3;
        if (y!=255)
        {
            return -1;
        }

        r = qRed(image.pixel(j,image.height()-2));
        g = qGreen(image.pixel(j,image.height()-2));
        b = qBlue(image.pixel(j,image.height()-2));
        y = (r+g+b)/3;
        if (y!=255)
        {
            return -1;
        }
        r = qRed(image.pixel(j,image.height()-1));
        g = qGreen(image.pixel(j,image.height()-1));
        b = qBlue(image.pixel(j,image.height()-1));
        y = (r+g+b)/3;
        if (y!=255)
        {
            return -1;
        }
    }
    return 0;
}


