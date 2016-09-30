#ifndef FORMBINARIZATION_H
#define FORMBINARIZATION_H

#include <QDialog>
#include <image.h>

namespace Ui {
class FormBinarization;
}

class FormBinarization : public QDialog
{
    Q_OBJECT
    
public:
    explicit FormBinarization(QWidget *parent = 0);
    ~FormBinarization();

signals:
    void send_threshold(int n, My_Image im);
    void send_data(int n,My_Image img);
private slots:
    void on_horizontalSlider_valueChanged(int value);

    void on_pushButton_clicked();

    void on_pushButton_2_clicked();

    void set_image(int m,My_Image img);

private:
   // QGraphicsScene *scene;
    My_Image im;
    Ui::FormBinarization *ui;
};

#endif // FORMBINARIZATION_H
