#include "formbrightness.h"
#include "ui_formbrightness.h"

FormBrightness::FormBrightness(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::FormBrightness)
{
    ui->setupUi(this);
    n1 =0;
    n2=0;
}

FormBrightness::~FormBrightness()
{
    delete ui;
}
void FormBrightness::set_image(int n,My_Image img)
{
    int i,j;
    im.pix=img.pix;
    im.rate = img.rate;
    im.matr = (int **)malloc(im.pix.width() * sizeof(int *));
    for(i = 0; i < img.pix.width(); i++)
    {
       im.matr[i] = (int *)malloc(im.pix.height() * sizeof(int));
    }
    for (i=0;i<img.pix.width();i++)
    {
        for (j=0;j<img.pix.height();j++)
        {
            im.matr[i][j] = img.matr[i][j];
        }
    }
}

void FormBrightness::on_horizontalSlider_valueChanged(int value)
{
   /* n1 = value;
    emit send_br_data(n1,n2,im);*/
}

void FormBrightness::on_horizontalSlider_2_valueChanged(int value)
{
   /* n2 = value;
    emit send_br_data(n1,n2,im);*/
}

void FormBrightness::on_pushButton_clicked()
{
    emit send_br_data(-256,-256,im,0);
    close();
}

void FormBrightness::on_pushButton_2_clicked()
{
    emit send_br_data(0,0,im,0);
    close();
}

void FormBrightness::on_horizontalSlider_2_sliderMoved(int position)
{

    n2 = position;
    emit send_br_data(n1,n2,im,1);
    ui->label->setText(QString("%1").arg(position));
}

void FormBrightness::on_horizontalSlider_actionTriggered(int action)
{

}

void FormBrightness::on_horizontalSlider_sliderMoved(int position)
{
    n1 = position;
    emit send_br_data(n1,n2,im,2);
    ui->label->setText(QString("%1").arg(position));
}
