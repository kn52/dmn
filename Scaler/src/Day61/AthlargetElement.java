package Day61;

public class AthlargetElement {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public static int[] solve(int A, int[] B) {
        int N = B.length;
        int[] heap = new int[A];

        for(int i = 0 ; i < A ; i++){
            heap[i] = B[i];
           
            if(i < A-1){
                B[i] = -1;
            }
        }

        for(int i = A/2 ; i >=0 ;i--){
            Min_downheap(heap,i);
        }

        B[A-1] = heap[0];

        for(int i = A ; i < N ; i++){

            if(B[i] > heap[0]){
                heap[0] = B[i];
                    Min_downheap(heap,0);
            }
            B[i] = heap[0];
        }
        return B;
    }
    public static void Min_downheap(int[] A, int i){
        int N = A.length;
        int L = (2*i)+1;
        int R = (2*i)+2;

        while(L < N){

            if(R == N){
                if(A[L] < A[i]){
                    swap(A,L,i);
                }
                break;
            }

            if(A[L] < A[i] && A[L] <= A[R]){
                swap(A,L,i);
                i = L;
                L = (2*i)+1;
                R = (2*i)+2;                
            }else if(A[R] < A[i] && A[R] < A[L]){
                swap(A,R,i);
                i = R;
                L = (2*i)+1;
                R = (2*i)+2;                  
            }else{
                break;
            }
        }
    }
   

    public static void swap(int[] A , int i , int j){
        int temp = A[i];
        A[i] = A[j];
        A[j] = temp;
    }

}
