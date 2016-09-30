#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <image.h>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    scene = new QGraphicsScene(ui->graphicsView);
    img.is_binary=false;
    img.matr_height=-1;
    img.matr_width=-1;

    /*img.pix.load("im2.jpg");
    img.matr = (int **)malloc(img.pix.width() * sizeof(int *));
    for(i = 0; i < img.pix.width(); i++)
    {
        img.matr[i] = (int *)malloc(img.pix.width() * sizeof(double));
    }

    scene->addPixmap((img.pix));
    printf("%d\n",img.pix.width());
    ui->graphicsView->setScene(scene);*/
}

MainWindow::~MainWindow()
{
    delete ui;
}
int MainWindow::check_image(int code)
{
    if ((img.matr_height<0))
    {
        QMessageBox::critical(NULL, QObject::tr("Ошибка!"),tr("Изображение не загружено!"));
        return -1;
    }
    else
        if ((img.is_binary!=true)&&(code==1))
        {
            QMessageBox::critical(NULL, QObject::tr("Ошибка!"),tr("Изображение не бинаризовано!"));
            return -2;
        }
    return 0;
}

void MainWindow::create_image_form(){
    d[dcount] = new Form(this);
    d[dcount]->setWindowTitle(QString("%1").arg(dcount));
    d[dcount]->set_number(dcount);
    d[dcount]->show();
    d[dcount]->set_image(img);
    d[dcount]->init_scene();

   // connect(this,SIGNAL(send_data(int,My_Image)),d[dcount],SLOT(recieve(int,My_Image)));
    connect(d[dcount],SIGNAL(sendnum(int,My_Image)),this,SLOT(recieve_n(int,My_Image)));
    //emit send_data(dcount,img);
    dcount++;

}

void MainWindow::on_pushButton_clicked()
{
    if (check_image(0)==0)
    {
    //img.negativ();
    img.otsu();
    img.is_binary = true;

    img.convert();
    //img.make_cart();
    img.back_conv();

    scene->addPixmap(img.pix);
    ui->graphicsView->setScene(scene);
    create_image_form();
    }

}

void MainWindow::on_pushButton_2_clicked()
{
    if (check_image(1)==0)
    {
    //img.make_cart();
    img.erode();
    img.check_erode_dilate();

    //img.morpho_border_correct();
    img.back_conv();
    scene->addPixmap(img.pix);
    ui->graphicsView->setScene(scene);
    create_image_form();
    }
}

void MainWindow::on_pushButton_3_clicked()
{
    if (check_image(1)==0)
    {
    //img.make_cart();
    img.check_erode_dilate();
    img.dilate();
    img.check_erode_dilate();

    //img.morpho_border_correct();
    img.back_conv();
    scene->addPixmap(img.pix);
    ui->graphicsView->setScene(scene);
    create_image_form();
    }
}

void MainWindow::on_pushButton_4_clicked()
{
    //img.convert();
    if (check_image(1)==0)
    {
    img.make_border();
    img.convert();
    img.back_conv();
    scene->addPixmap(img.pix);
    ui->graphicsView->setScene(scene);
    create_image_form();
    }
}

void MainWindow::on_pushButton_5_clicked()
{
    /*d[dcount] = new Form(this);
    d[dcount]->setWindowTitle(QString("%1").arg(dcount));
    d[dcount]->set_number(dcount);
    d[dcount]->show();

    connect(this,SIGNAL(send_n(int)),d[dcount],SLOT(recieve(int)));
    connect(d[dcount],SIGNAL(sendnum(int)),this,SLOT(recieve_n(int)));
    emit send_n(dcount);
    dcount++;*/
    if (check_image(0)==0)
    {
    img.negativ();
    scene->addPixmap(img.pix);
    ui->graphicsView->setScene(scene);
    create_image_form();
    }
}

void MainWindow::recieve_n(int x,My_Image im){
    int i,j;
    active_window = x;
    img.pix = im.pix;
    img.rate = im.rate;
    for (i=0;i<im.pix.width();i++)
    {
        for (j=0;j<im.pix.height();j++)
        {
            img.matr[i][j] = im.matr[i][j];
        }
    }
    img.is_saved = im.is_saved;
    img.is_binary = im.is_binary;
    zagl=0;//**********
    scene->addPixmap(img.pix);
    ui->graphicsView->setScene(scene);
    ui->label->setText(QString("%1").arg(active_window));
}

void MainWindow::recieve_threshold(int n, My_Image im){
    //QImage image(im.pix.toImage());
   // QPixmap::fromImage(image).save("rab_bin.jpg");
   // img.pix.load("rab_bin.jpg");
    int i,j;
    if (n>=0)
    {
    img.pix = im.pix;
    img.rate = im.rate;
    for (i=0;i<im.pix.width();i++)
    {
        for (j=0;j<im.pix.height();j++)
        {
            img.matr[i][j] = im.matr[i][j];
        }
    }
    img.handy_binarization(n);
    img.is_binary=true;
    ui->label->setText(QString("%1").arg(n));
    scene->addPixmap(img.pix);
    ui->graphicsView->setScene(scene);
    }
    else
    {
        img.is_binary=true;
        img.convert();
        //img.make_cart();
        img.back_conv();
        img.dilate();
        img.back_conv();
        img.erode();
        img.back_conv();
        create_image_form();
    }
}

void MainWindow::on_pushButton_6_clicked()//открыть файл кудиалогом
{
    QString filename = QFileDialog::getOpenFileName(
                this,
                tr("Открыть файл"),
                "D:\QtVit\Qt5.1.0\Tools\QtCreator\bin\build-prototype-Desktop_Qt_5_1_0_MinGW_32bit-Debug",
                "Все файлы (*.*);;BMP (*.bmp);;JPEG (*.jpg);;TIFF (*.tiff);; PNG (*.png)"
                );
    QMessageBox::information(this,tr("File name"),filename);
    if (!(filename.isEmpty()))
    {
    img.pix.load(filename);
    img.matr_height = img.pix.width();
    img.matr_width = img.pix.height();
    img.rate = 1.0;
    img.matr = (int **)malloc(img.pix.width() * sizeof(int *));
    for(i = 0; i < img.pix.width(); i++)
    {
       img.matr[i] = (int *)malloc(img.pix.height() * sizeof(int));
    }
    img.is_binary = false;
    img.is_saved = 1;

    scene->addPixmap((img.pix));
    //printf("%d\n",img.pix.width());
    ui->graphicsView->setScene(scene);
    ui->pushButton_6->setEnabled(false);
    }
}

void MainWindow::on_pushButton_7_clicked()//сохранить файл
{
    if (check_image(0)==0)
    {
    if (img.is_saved == 0){
    QString filename = QFileDialog::getSaveFileName(
                this,
                tr("Сохранить файл"),
                "C://",
                "Все файлы (*.*);;BMP (*.bmp);;JPEG (*.jpg);;TIFF (*.tiff);; PNG (*.png)"
                );
    QMessageBox::information(this,tr("File name"),filename);
    QImage image(img.pix.toImage());
    QPixmap::fromImage(image).save(filename);
    d[active_window]->set_saved(1);
    img.is_saved = 1;
}
    }
}

void MainWindow::recieve_data(int x, My_Image im)
{
    int i,j;
    img.pix = im.pix;
    img.rate = im.rate;
    img.is_binary = im.is_binary;
    for (i=0;i<im.pix.width();i++)
    {
        for (j=0;j<im.pix.height();j++)
        {
            img.matr[i][j] = im.matr[i][j];
        }
    }
    scene->addPixmap(img.pix);
    ui->graphicsView->setScene(scene);
}

void MainWindow::on_pushButton_8_clicked()//бинаризация ручная
{
    if (check_image(0)==0)
    {
    FormBinarization *form = new FormBinarization(this);
    form->setModal(true);
    form->show();

    connect(form,SIGNAL(send_threshold(int,My_Image)),this,SLOT(recieve_threshold(int,My_Image)));
    connect(this,SIGNAL(send_data(int,My_Image)),form,SLOT(set_image(int,My_Image)));
    connect(form,SIGNAL(send_data(int,My_Image)),this,SLOT(recieve_data(int,My_Image)));

    emit send_data(1,img);
    }

}
void MainWindow::delete_particles()
{
    //(TParticle *)realloc(img.particles,0);
    free(img.particles);
    img.particles = new TParticle;
}

void MainWindow::on_pushButton_9_clicked()//автоматические измерения
{
    if (zagl!=0)
    {
        QMessageBox::critical(NULL, QObject::tr("Ошибка!"),tr("Выберите изображение!"));
    }
    else
    {
    if (check_image(1)==0)
    {
        if (img.check_border()>=0)
        {
            zagl++;
            int num;
            num = img.make_calculations();
            // TableCalculationForm *form;

            TableCalculationForm *form = new TableCalculationForm(this);
            form->setModal(true);
            form->show();

            connect(this,SIGNAL(send_particles(TParticle*,int)),form,SLOT(receive_particles(TParticle*,int)));
            connect(form,SIGNAL(closed()),this,SLOT(delete_particles()));
            emit send_particles(img.particles,num);
        }
        else
        {
            QMessageBox::critical(NULL, QObject::tr("Ошибка!"),tr("Края не обработаны!"));
        }
    }
    }
}
void MainWindow::receive_br_data(int n1, int n2, My_Image im,int pr)
{
    int i,j;
    if ((n1>-256)&&(n2>-256))
    {
    img.pix = im.pix;
    img.rate = im.rate;
    img.is_binary = im.is_binary;
    for (i=0;i<im.pix.width();i++)
    {
        for (j=0;j<im.pix.height();j++)
        {
            img.matr[i][j] = im.matr[i][j];
        }
    }
    if (pr==0)
    {
        img.brightness(n1);
        img.contrast(n2);
    }
    if (pr==2)
    img.brightness(n1);
    if (pr==1)
    img.contrast(n2);
    scene->addPixmap(img.pix);
    ui->graphicsView->setScene(scene);
    }
    else
    {
        create_image_form();
    }
}

void MainWindow::on_pushButton_10_clicked()//brightness+contrast
{
    if (check_image(0)==0)
    {
    FormBrightness *form = new FormBrightness(this);
    form->setModal(true);
    form->show();

    connect(form,SIGNAL(send_br_data(int,int,My_Image,int)),this,SLOT(receive_br_data(int,int,My_Image,int)));
    connect(this,SIGNAL(send_data(int,My_Image)),form,SLOT(set_image(int,My_Image)));

    emit send_data(1,img);
    }
}
void MainWindow::receive_rate(double rate)
{
    img.rate = rate;
    d[active_window]->set_rate(rate);
}

void MainWindow::on_pushButton_11_clicked()//tariration
{
    if (check_image(0)==0)
    {
    FormTariration *form = new FormTariration(this);
    form->setModal(true);
    form->show();

    connect(form,SIGNAL(send_tar_data(double)),this,SLOT(receive_rate(double)));
    }
}
