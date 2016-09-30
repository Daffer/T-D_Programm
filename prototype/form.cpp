#include "form.h"
#include "ui_form.h"

Form::Form(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Form)
{
    //scene = new QGraphicsScene(ui->graphicsView);
    ui->setupUi(this);
}

Form::~Form()
{
    delete ui;
}

void Form::mousePressEvent(QMouseEvent *pt){
    if (ui->graphicsView->isActiveWindow())
    emit sendnum(number,im);
}
void Form::closeEvent(QCloseEvent *cl){
    if (im.is_saved == 0){
    QString filename = QFileDialog::getSaveFileName(
                this,
                tr("Сохранить файл"),
                "C://",
                "Все файлы (*.*);;BMP (*.bmp);;JPEG (*.jpg);;TIFF (*.tiff);; PNG (*.png)"
                );
    QMessageBox::information(this,tr("File name"),filename);
    QImage image(im.pix.toImage());
    QPixmap::fromImage(image).save(filename);
    im.is_saved = 1;
    }
}

void Form::set_number(int n){
    number = n;
}
void Form::set_image(My_Image img){
    int i,j;
    im.pix = img.pix;
    im.rate = img.rate;
    im.is_binary=img.is_binary;

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
    im.is_saved = 0;
}
void Form::set_saved(int n){
    im.set_is_saved(n);
}
void Form::set_rate(double rate){
    im.rate = rate;
}

void Form::init_scene(){
    scene = new QGraphicsScene(ui->graphicsView);
    scene->addPixmap(im.pix);
    ui->graphicsView->setScene(scene);
}

void Form::recieve(int x,My_Image img)
{
    //scene->addPixmap(img.pix);
    //ui->graphicsView->setScene(scene);
    //number = x;
    //ui->label->setText(QString("%1").arg(x));
}
