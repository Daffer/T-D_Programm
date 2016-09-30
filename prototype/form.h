#ifndef FORM_H
#define FORM_H

#include <QDialog>
#include <image.h>
#include <QGraphicsView>
#include <QGraphicsScene>
#include <QFileDialog>
#include <QMessageBox>
#include <QImage>

namespace Ui {
class Form;
}

class Form : public QDialog
{
    Q_OBJECT
    
public:

    explicit Form(QWidget *parent = 0);
    ~Form();
    void init_scene();
    //void show_image();

    void set_number(int n);
    void set_image(My_Image img);
    void set_saved(int n);
    void set_rate(double rate);
signals:
    void sendnum(int,My_Image);
private slots:
    void recieve(int x,My_Image img);
protected:
    virtual void mousePressEvent(QMouseEvent *);
    virtual void closeEvent(QCloseEvent *);
    
private:
    int number;
    QGraphicsScene *scene;
    My_Image im;
    Ui::Form *ui;
};

#endif // FORM_H
