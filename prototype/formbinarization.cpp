#include "formbinarization.h"
#include "ui_formbinarization.h"

FormBinarization::FormBinarization(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::FormBinarization)
{
    ui->setupUi(this);
    emit send_threshold(ui->horizontalSlider->value(),im);
   // scene = new QGraphicsScene(ui->graphicsView);

  //  scene->addPixmap(im.pix);
   // ui->graphicsView->setScene(scene);
}

FormBinarization::~FormBinarization()
{
    delete ui;
}
void FormBinarization::set_image(int m,My_Image img){
    int i,j;
    im.pix = img.pix;
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
    //im = img;
    ui->label_4->setText(QString("%1").arg(111111111));

}
void FormBinarization::on_horizontalSlider_valueChanged(int value)
{
    emit send_threshold(value,im);
    ui->label_4->setText(QString("%1").arg(value));
}

void FormBinarization::on_pushButton_clicked()
{
    emit send_threshold(-1,im);
    close();
}

void FormBinarization::on_pushButton_2_clicked()//jnvtyf
{
    emit send_data(ui->horizontalSlider->value(),im);
    close();
}

